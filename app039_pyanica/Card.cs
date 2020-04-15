using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CardRank : int
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
    Ace = 14
}
public enum CardSuit : int
{
    Diamonds = 1,
    Clubs = 2,
    Hearts = 3,
    Spades = 4
}
public enum CardSide : int
{
    Back = 1,
    Face = 2
}
class Card
{
    #region Статические поля
    private static Dictionary<CardRank, String> dicCardRank = new Dictionary<CardRank, string>()
    {
        {CardRank.Two, "2"},
        {CardRank.Three, "3"},
        {CardRank.Four, "4"},
        {CardRank.Five, "5"},
        {CardRank.Six, "6"},
        {CardRank.Seven, "7"},
        {CardRank.Eight, "8"},
        {CardRank.Nine, "9"},
        {CardRank.Ten, "10"},
        {CardRank.Jack, "J"},
        {CardRank.Queen, "Q"},
        {CardRank.King, "K"},
        {CardRank.Ace, "A"}
    };

    private static Dictionary<CardSuit, Char> dicCardSuit = new Dictionary<CardSuit, Char>()
    {
        {CardSuit.Diamonds, '♦'},
        {CardSuit.Clubs, '♣'},
        {CardSuit.Hearts, '♥'},
        {CardSuit.Spades, '♠'}
    };
    #endregion

    #region Локальные поля 
    private string _name;
    private CardRank _rank;
    private CardSuit _suit;
    private CardSide _side;
    #endregion

    #region Конструктор
    public Card(CardRank rank, CardSuit suit)
    {
        if (rank < CardRank.Two || rank > CardRank.Ace) { throw new ArgumentNullException("Карта не может быть меньшь 2 и больше Туза"); }
        _rank = rank;

        //Релизовать через оператор сравнения с перечислением CardSuit
        if (!"♠♣♦♥".Contains(dicCardSuit[(CardSuit)suit])) { throw new ArgumentNullException("Данная масть не существует"); }
        _suit = suit;

        _side = CardSide.Back;
        _name = dicCardRank[rank] + dicCardSuit[suit];
    }
    #endregion

    #region Свойства

    public CardRank Rank => _rank;
    public CardSuit Suit => _suit;
    public CardSide Side
    {
        get { return _side; }
        set
        {
            if ((value < CardSide.Back) || (value > CardSide.Face)) { throw new ArgumentException("Неверная сторона каты"); }
            _side = value;
        }
    }
    public string Image => "╔════╗\n║" + ((_side == CardSide.Back) ? "╳╳╳╳║\n║╳╳╳╳" : ("    ║\n║" + _name.PadLeft(4, ' '))) + "║\n╚════╝\n";

    #endregion

    #region Методы
    public void FlipSide() { _side = CardSide.Face; }
    #endregion

}

