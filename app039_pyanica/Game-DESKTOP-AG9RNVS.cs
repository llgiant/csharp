using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Player
{
	None,
	Left,
	Right
}
public enum Stopka
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
		Decks[Stopka.PlayerRight].AddToBottom(cards);
	}
	#endregion

	#region Функции

	public string _step()
	{
		bool flipCard = true;                               //Переключатель сторон
		Player takePlayer = Player.None;                    //Игрок - победитель который берет карты в конце хода
		int countBack = 0;                                  //Счетчик споров
        int count = 0;                                     // промежуточный счетчик перевернутых карт
		int countPL = Decks[Stopka.PlayerLeft].Count;       //Счетчик карт левого игрока
		int countPR = Decks[Stopka.PlayerRight].Count; //Счетчик карт правого игрока

        if (countPL > 0 && countPR > 0)
		{
            do
            {               
                if (!flipCard) { count--; }

                Card card1 = Decks[Stopka.PlayerLeft].GetCard();
                Decks[Stopka.PlayerLeft].Remove(card1);
                Card card2 = Decks[Stopka.PlayerRight].GetCard();
                Decks[Stopka.PlayerRight].Remove(card2);
                if (flipCard || countPL == 0 || countPR == 0) { card1.flipSide(); card2.flipSide(); }
               
                Decks[Stopka.TablePlayerLeft].AddToTop(card1);
                Decks[Stopka.TablePlayerRight].AddToTop(card2);

                //Отрисовка

                if (countPL > 0 && countPR > 0)
                {
                    if (count == 0 && countBack > 0 && !flipCard) { flipCard = true; continue; }
                    if (count > 0) { continue; }
                }
                takePlayer = playerWhoTakes() == Player.None ?
                    Player.None : playerWhoTakes() == Player.Left ?
                    Player.Left : Player.Right;

               countBack++; //3
               if(count > 0) { continue; }
               count = countBack;              
               flipCard = false;

            } while (takePlayer == Player.None);

        }

		if (takePlayer == Player.Left)
		{

		}
		else if (takePlayer == Player.Right)
		{

		}
		return "";
	}

	Player playerWhoTakes()
	{
		Player player = Player.None;

		Card card1 = Decks[Stopka.TablePlayerLeft].GetCard();
		Card card2 = Decks[Stopka.TablePlayerRight].GetCard();

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

		return player;
	}

    public string Draw(Card leftPlayerCard, Card rightPlCard, Player takePlayer) 
    {
        string result = "";
        Player takeplayer = playerWhoTakes();

        switch (takeplayer)
        {
            case Player.None:
                return leftPlayerCard.Image() + " = " + rightPlCard.Image() + "\n" + "    ";
                break;
            case Player.Left:
                return leftPlayerCard.Image() + " > " + rightPlCard.Image();
                break;
            case Player.Right:
                return leftPlayerCard.Image() + " < " + rightPlCard.Image();
                break;
        }
        return result;
    }



	#endregion

}

