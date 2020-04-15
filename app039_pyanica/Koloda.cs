using System;
using System.Collections.Generic;

class Koloda
{
    #region Переменные
    private static Random rnd = new Random();
    List<Card> _deck = new List<Card>();
    private int _count;
    #endregion

    #region Методы
    public void AddToTop(Card card)
    {
        if (card == null) { }
        if (_deck.Contains(card)) { }
        _deck.Insert(0, card);
    }

    public void AddToBottom(Card[] deck)
    {
        if (deck == null) { }
        if (deck.Length == 0) { }
        foreach (Card card in deck)
        {
            card.Side = CardSide.Back;
            AddToBottom(card);
        }
    }

    public void AddToBottom(Card card) { _deck.Add(card); }

    public void Remove(Card card) { _deck.Remove(card); }

    public void RemoveAllCards() { _deck.Clear(); }

    #endregion


    #region Функция
    public Card GetTopCard() { return _deck[0]; }
    #endregion

    #region Свойства
    public int Count => _deck.Count;
    public Card[] GetDeck => _deck.ToArray();
    #endregion
}

