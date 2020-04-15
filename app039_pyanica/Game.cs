using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Player : int
{
    None,
    Left,
    Right
}

public enum Stopka : int
{
    PlayerLeft = 1,
    PlayerRight = 2,
    TablePlayerLeft = 3,
    TablePlayerRight = 4
}

class Game
{
    #region Переменные
    private Random rnd = new Random();
    public Player _whoTakes;
    private bool _isFinal = false;
    private Player _loser;
    private Player _winner;
    List<Card> cards;

    Dictionary<Stopka, Koloda> Decks = new Dictionary<Stopka, Koloda>()
        {
            { Stopka.PlayerLeft, new Koloda() },
            { Stopka.PlayerRight, new Koloda() },
            { Stopka.TablePlayerLeft, new Koloda() },
            { Stopka.TablePlayerRight, new Koloda() }
        };
    #endregion

    #region Конструктор
    public Game()
    {
        //Заполнение колоды

        cards = new List<Card>();
        Card card = null;
        for (int suit = 1; suit < 5; suit++)
        {
            for (int rank = 2; rank < 15; rank++)
            {
                card = new Card((CardRank)rank, (CardSuit)suit);
                cards.Add(card);
            }
        }

        //РАЗДАЧА КАРТ
        Card addedCard;
        int index;
        do
        {
            index = rnd.Next(0, cards.Count);
            addedCard = cards[index];
            Decks[Stopka.PlayerLeft].AddToTop(addedCard);
            cards.Remove(addedCard);
        } while (cards.Count > 26);
        Decks[Stopka.PlayerRight].AddToBottom(cards.ToArray());
    }
    #endregion

    #region Функции

    public Player Step()
    {
        bool flipCard = true;                               //Переключатель сторон
        Player takePlayer = Player.None;                    //Игрок - победитель который берет карты в конце хода
        int countBack = 0;                                  //Счетчик споров
        int count = 0;                                     // промежуточный счетчик перевернутых карт
        int countPL = Decks[Stopka.PlayerLeft].Count;       //Счетчик карт левого игрока
        int countPR = Decks[Stopka.PlayerRight].Count; //Счетчик карт правого игрока
        if (countPL > 0 && countPR > 0)
        {
            if (Decks[Stopka.TablePlayerLeft].Count > 0)
            {                             
                TakeCards();
                ClearDeck();
            }

            do
            {
                if (!flipCard) { count--; }

                Card card1 = Decks[Stopka.PlayerLeft].GetTopCard();
                Decks[Stopka.PlayerLeft].Remove(card1);

                Card card2 = Decks[Stopka.PlayerRight].GetTopCard();
                Decks[Stopka.PlayerRight].Remove(card2);

                if (flipCard || countPL == 0 || countPR == 0) { card1.FlipSide(); card2.FlipSide(); }

                Decks[Stopka.TablePlayerLeft].AddToTop(card1);
                Decks[Stopka.TablePlayerRight].AddToTop(card2);

                if (countPL > 0 && countPR > 0)
                {
                    if (count == 0 && countBack > 0 && !flipCard) { flipCard = true; continue; }
                    if (count > 0) { continue; }
                }
                takePlayer = playerWhoTakes();
                

                countBack++; //3
                if (count > 0) { continue; }
                count = countBack;
                flipCard = false;

            } while (takePlayer == Player.None);
        }
        if (countPL == 0 || countPR == 0) { 

            _isFinal = true; _winner = Decks[Stopka.PlayerRight].Count == 0 ? Player.Left : Player.Right;
            _loser = _winner == Player.Left ? Player.Left : Player.Right;
        }
        return takePlayer;
    }


    public void TakeCards()
    {
        Koloda deck = null;
        deck = _whoTakes == Player.Left ? Decks[Stopka.PlayerLeft] : Decks[Stopka.PlayerRight];
        deck.AddToBottom(Decks[Stopka.TablePlayerRight].GetDeck);
        deck.AddToBottom(Decks[Stopka.TablePlayerLeft].GetDeck);
    }

    Player playerWhoTakes()
    {
        Player player = Player.None;

        Card card1 = Decks[Stopka.TablePlayerLeft].GetTopCard();
        Card card2 = Decks[Stopka.TablePlayerRight].GetTopCard();

        if (card1.Rank == CardRank.Six && card2.Rank == CardRank.Ace)
            player = Player.Left;
        else if (card1.Rank == CardRank.Seven && card2.Rank == CardRank.King)
            player = Player.Left;
        else if (card1.Rank == CardRank.Eight && card2.Rank == CardRank.Queen)
            player = Player.Left;
        else if (card1.Rank == CardRank.Nine && card2.Rank == CardRank.Jack)
            player = Player.Left;
        else if (card1.Rank == CardRank.Jack && card2.Rank == CardRank.Nine)
            player = Player.Right;
        else if (card1.Rank == CardRank.Queen && card2.Rank == CardRank.Eight)
            player = Player.Right;
        else if (card1.Rank == CardRank.King && card2.Rank == CardRank.Seven)
            player = Player.Right;
        else if (card1.Rank == CardRank.Ace && card2.Rank == CardRank.Six)
            player = Player.Right;
        else if (card1.Rank > card2.Rank)
            player = Player.Left;
        else if (card2.Rank > card1.Rank)
            player = Player.Right;
        _whoTakes = player;
        return player;
    }

    public string Draw()
    {
        Card[] playerLeftCards = Decks[Stopka.TablePlayerLeft].GetDeck;
        Card[] playerRightCards = Decks[Stopka.TablePlayerRight].GetDeck;
        string strCard = "";
        string[] strPart1;
        string[] strPart2;

        for (int i = playerLeftCards.Length - 1; i >= 0; i--)
        {
            strPart1 = playerLeftCards[i].Image.Split('\n');
            strPart2 = playerRightCards[i].Image.Split('\n');

            for (int j = 0; j < strPart1.Length - 1; j++)
            {
                if (j != 2) { strCard += strPart1[j] + " " + strPart2[j] + "\n"; }
                else
                {
                    if (playerLeftCards[i].Side == CardSide.Face)
                    {
                        if (playerLeftCards[i].Rank == playerRightCards[i].Rank) { strCard += strPart1[j] + "=" + strPart2[j] + "\n"; }
                        else { strCard += strPart1[j] + checkSign() + strPart2[j] + "\n"; }
                    }
                    else { strCard += strPart1[j] + " " + strPart2[j] + "\n"; }
                }
            }
        }

        if (Decks[Stopka.PlayerLeft].Count < 10) { strCard += $"     {Decks[Stopka.PlayerLeft].Count}"; }
        else { strCard += $"    {Decks[Stopka.PlayerLeft].Count}"; }

        if (Decks[Stopka.PlayerRight].Count < 10) { strCard += $"      {Decks[Stopka.PlayerRight].Count}\n"; }
        else { strCard += $"     {Decks[Stopka.PlayerRight].Count}\n"; }

        return strCard;
    }

    public string checkSign()
    {
        if (_whoTakes == Player.Left) { return ">"; }
        if (_whoTakes == Player.Right) { return "<"; }
        return "";
    }
    #endregion

    #region Свойства
    public bool IsFinal { get { return _isFinal; } }

    public Player Winner
    {
        get { return _winner; }
        set { _winner = value; }
    }

    public Player Loser
    {
        get { return _loser; }
        set { _loser = value; }
    }

    public void ClearDeck()
    {
        Decks[Stopka.TablePlayerRight].RemoveAllCards();
        Decks[Stopka.TablePlayerLeft].RemoveAllCards();
    }
    #endregion

}