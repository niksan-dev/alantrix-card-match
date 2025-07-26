
using System;
using UnityEngine;

namespace Niksan.CardGame
{
    public class ScoreManager : MonoBehaviour
    {
        public int CurrentScore { get; private set; }
        public int MatchStreak { get; private set; }

        private void OnEnable()
        {
            EventBus.OnCardsMatched += OnCardsMatched;
            EventBus.OnCardsMismatched += OnCardsMismatched;
        }

        void OnCardsMatched(ICard card,ICard otherCard)
        {
            AddMatchScore();
        }

        void OnCardsMismatched(ICard card, ICard otherCard)
        {
            ResetScore();
        }

        private void OnDisable()
        {
            EventBus.OnCardsMatched -= OnCardsMatched;
            EventBus.OnCardsMismatched -= OnCardsMismatched;
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            MatchStreak = 0;
            EventBus.RaiseScoreUpdate(CurrentScore, MatchStreak);
        }

        public void AddMatchScore()
        {
            MatchStreak++;
            int bonus = MatchStreak * 20;
            int scoreToAdd = 100 + bonus;
            CurrentScore += scoreToAdd;
            EventBus.RaiseScoreUpdate(CurrentScore, MatchStreak);
        }

        public void ResetStreak()
        {
            MatchStreak = 0;
            EventBus.RaiseScoreUpdate(CurrentScore, MatchStreak);
        }
    }
}
