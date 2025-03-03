using System;
using System.Collections.Generic;

namespace _Project.Scripts.Screens
{
    public static class PokerHandEvaluator
    {
        public enum HandRank
        {
            HighCard = 1,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush
        }

        private static readonly HashSet<Suits> _suits = new();
        private static readonly HashSet<int> _ranks = new();
        private static readonly Dictionary<int, int> _rankCount = new();
        private static readonly int[] _rankGroups = new int[5];

        public static HandRank EvaluateHand(List<CardsSelected> selectedCards)
        {
            // Early return for invalid hands
            if (selectedCards == null || selectedCards.Count < 5)
                return HandRank.HighCard;

            _suits.Clear();
            _ranks.Clear();
            _rankCount.Clear();

            int minRank = 13;
            int maxRank = -1;
            int validCards = 0;
            
            foreach (var cardSlot in selectedCards)
            {
                if (cardSlot?.SelectedCard == null) continue;

                validCards++;
                int rank = (int)cardSlot.SelectedCard.CardValue;

                _suits.Add(cardSlot.SelectedCard.CardsSuit);
                _ranks.Add(rank);
                _rankCount[rank] = _rankCount.TryGetValue(rank, out int count) ? count + 1 : 1;

                minRank = Math.Min(minRank, rank);
                maxRank = Math.Max(maxRank, rank);
            }

            if (validCards != 5) return HandRank.HighCard;

            bool isFlush = _suits.Count == 1;

            bool isStraight = false;
            if (_ranks.Count == 5)
            {
                isStraight = (maxRank - minRank == 4) ||
                             _ranks.Contains(12) && 
                             _ranks.Contains(0) &&
                             _ranks.Contains(1) &&
                             _ranks.Contains(2) &&
                             _ranks.Contains(3);
            }

            if (isStraight && isFlush) return HandRank.StraightFlush;

            // Count rank frequencies
            int pairCount = 0;
            bool hasThree = false;
            bool hasFour = false;

            foreach (var count in _rankCount.Values)
            {
                switch (count)
                {
                    case 4: hasFour = true; break;
                    case 3: hasThree = true; break;
                    case 2: pairCount++; break;
                }
            }

            if (hasFour) return HandRank.FourOfAKind;
            if (hasThree && pairCount > 0) return HandRank.FullHouse;
            if (isFlush) return HandRank.Flush;
            if (isStraight) return HandRank.Straight;
            if (hasThree) return HandRank.ThreeOfAKind;
            if (pairCount == 2) return HandRank.TwoPair;
            if (pairCount == 1) return HandRank.OnePair;

            return HandRank.HighCard;
        }
    }
}