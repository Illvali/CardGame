using System;
using System.Collections.Generic;


namespace Cardgame
{
    class Hand
    {
        private List<Card> _cardsOnHand;
        private int _colorMatches;
        private int _valueMatches;

        public Hand()
        {
            _cardsOnHand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cardsOnHand.Add(card);
        }

        public void SortHand()
        {
            _cardsOnHand.Sort((x, y) => x.Value.CompareTo(y.Value));
        }

        public void ShowHand()
        {
            foreach (var card in _cardsOnHand)
            {
                card.PresentCard();
            }
        }

        private bool CheckIfSameColor()
        {
            foreach (var card in _cardsOnHand)
            {
                if (_cardsOnHand[0].Color == card.Color)
                {
                    _colorMatches++;
                }
            }
            if (_colorMatches == _cardsOnHand.Count)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfFollowingValues()
        {
            for (int i = 0; i < _cardsOnHand.Count - 1; i++)
            {
                if (_cardsOnHand[i].Value + 1 == _cardsOnHand[i + 1].Value)
                {
                    _valueMatches++;
                }
            }
            if (_valueMatches == 4)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfRoyales()
        {
            if (_cardsOnHand[0].Royal == true)
            {
                return true;
            }
            return false;
        }

        public bool AnalyzeHandForStraightFlush()
        {
            SortHand();
            if (CheckIfSameColor() == true && CheckIfFollowingValues() == true )
            {
                return true;
            }
            return false;
        }
        public bool AnalyzeHandForRoyalStraightFlush()
        {
            SortHand();
            if (CheckIfSameColor() == true && CheckIfFollowingValues() == true && CheckIfRoyales() == true)
            {
                return true;
            }
            return false;
        }

        public bool AnalyzeHandForStraight()
        {
            SortHand();
            if (CheckIfFollowingValues() == true)
            {
                return true;
            }
            return false;
        }

        public bool AnalyzeHandForFlush()
        {
            SortHand();
            if (CheckIfSameColor() == true)
            {
                return true;
            }
            return false;
        }
    }
}
