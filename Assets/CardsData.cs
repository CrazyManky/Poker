using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CardsData : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;
    
    private List<Card> _availableCards = new();
    private Random _random = new Random();

    private void Awake() => ResetDeck();

    public Card GetRandomCard()
    {
        if (_availableCards.Count == 0)
            ResetDeck();
        int randomIndex = _random.Next(0, _availableCards.Count);
        Card selectedCard = _availableCards[randomIndex];
        _availableCards.RemoveAt(randomIndex);

        return selectedCard;
    }

    private void ResetDeck(){_availableCards = new List<Card>(_cards);}
}

[Serializable]
public class Card
{
    public Suits CardsSuit;
    public CardValue CardValue;
    public Sprite SpriteCard;
}