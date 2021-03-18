using System;
using System.Collections.Generic;


namespace Cardgame
{
    partial class Program
    {
        class Game
        {
            private readonly string[] _colors = { "heart", "diamond", "spade", "club" };
            private readonly int[] _values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
            private readonly string[] _showValues = {"Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            private List<Card> _deck;
            private bool _found;
            private int _handsAnalyzed;
            private Hand _currentHand = new Hand();
            public Game()
            {
                _found = false;
                CreateDeck();

            }

            private void CreateDeck()
            {
                _deck = new List<Card>();
                foreach (string color in _colors)
                {
                    foreach (int value in _values)
                    {
                        Card card = new Card(color, value, _showValues[value - 1]);
                        _deck.Add(card);
                    }
                }
            }

            public void HandleTry(string searchFor)
            {
                _found = false;
                if (searchFor == "f")
                {
                    TryFlush();
                }
                if (searchFor == "s")
                {
                    TryStraight();
                }
                if (searchFor == "sf")
                {
                    TryStraightFlush();
                }
                if (searchFor == "rsf")
                {
                    TryRoyalStraightFlush();
                }
            }

            private void TryFlush()
            {
                while (_found != true)
                {
                    ShuffleDeck();
                    _currentHand = DealHand();
                    _handsAnalyzed++;
                    _found = _currentHand.AnalyzeHandForFlush();
                }
                PresentFound("Flush");
            }
            private void TryStraight()
            {
                while (_found != true)
                {
                    ShuffleDeck();
                    _currentHand = DealHand();
                    _handsAnalyzed++;
                    _found = _currentHand.AnalyzeHandForStraight();
                }
                PresentFound("Straight");
            }

            private void TryStraightFlush()
            {
                while(_found != true)
                {
                    ShuffleDeck();
                    _currentHand = DealHand();
                    _handsAnalyzed++;
                    _found = _currentHand.AnalyzeHandForStraightFlush();
                }
                PresentFound("Straight Flush");
            }

            public void TryRoyalStraightFlush()
            {
                while (_found != true)
                {
                    ShuffleDeck();
                    _currentHand = DealHand();
                    _handsAnalyzed++;
                    _found = _currentHand.AnalyzeHandForRoyalStraightFlush();
                }
                PresentFound("Royal Straight Flush");
            }

            public void PresentFound(string foundType)
            {
                Console.WriteLine($"You found a {foundType}! In {_handsAnalyzed} tries");
                _currentHand.ShowHand();
                _handsAnalyzed = 0;
            }

            public void ShuffleDeck()
            {
                Random rand = new Random();
                for (int i = 0; i < _deck.Count; i++)
                {
                    int newIndex = rand.Next(_deck.Count - 1);
                    Card temp = _deck[i];
                    _deck[i] = _deck[newIndex];
                    _deck[newIndex] = temp;
                }
            }

            public Hand DealHand()
            {
                Hand hand = new Hand();
                for(int i=0; i < 5; i++)
                {
                    Card pickedCard = _deck[i];
                    hand.AddCard(pickedCard);
                }
                return hand;
            }
        }
    }
}
