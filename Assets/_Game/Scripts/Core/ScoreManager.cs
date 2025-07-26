
using System;
using UnityEngine;

namespace Niksan.CardGame
{
    public class ScoreManager : MonoBehaviour
    {
        internal int CurrentScore { get;  set; }
         int MatchStreak { get;  set; }

         const int PER_MATCH_POINTS = 100;
         const int BONUS = 15;
        private void OnEnable()
        {
            EventBus.OnCardsMatched += OnCardsMatched;
            EventBus.OnCardsMismatched += OnCardsMismatched;
            ResetScore();
        }

        void OnCardsMatched(ICard card,ICard otherCard)
        {
            AddMatchScore();
        }

        void OnCardsMismatched(ICard card, ICard otherCard)
        {
            ResetStreak();
        }

        private void OnDisable()
        {
            EventBus.OnCardsMatched -= OnCardsMatched;
            EventBus.OnCardsMismatched -= OnCardsMismatched;
            ResetScore();
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
            int bonus = MatchStreak * BONUS;
            int scoreToAdd = PER_MATCH_POINTS + bonus;
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
