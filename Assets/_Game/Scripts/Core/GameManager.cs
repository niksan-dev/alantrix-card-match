using System.Collections.Generic;
using Niksan.CardGame.Data;
using UnityEngine;

namespace Niksan.CardGame
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoardGenerator boardGenerator;
        [SerializeField] private MatchFinder matchFinder;
        [SerializeField] private List<LevelConfig> levels;
        private int totalCards;
        public int currentLevel = 1;

        void Start()
        {
            totalCards = levels[currentLevel].TotalCards; // e.g. set from level data
            matchFinder.Init(totalCards);
            boardGenerator.GenerateBoard(levels[currentLevel]);
        }
        
        private void OnEnable()
        {
            EventBus.OnCardsMatched += HandleMatch;
            EventBus.OnCardsMismatched += HandleMismatch;
            EventBus.OnLevelCompleted += HandleLevelComplete;
            EventBus.OnCardFlipped += HandleCardFlip;
        }

        private void OnDisable()
        {
            EventBus.OnCardsMatched -= HandleMatch;
            EventBus.OnCardsMismatched -= HandleMismatch;
            EventBus.OnLevelCompleted -= HandleLevelComplete;
            EventBus.OnCardFlipped -= HandleCardFlip;
        }

        private void HandleMatch(ICard a, ICard b) => Debug.Log("Match!");
        private void HandleMismatch(ICard a, ICard b) => Debug.Log("Mismatch!");
        private void HandleLevelComplete() => Debug.Log("Level Done!");
        private void HandleCardFlip(ICard card) => Debug.Log("Card Flipped: " + card.ID);

        public void OnCardClicked(ICard card)
        {
            //matchFinder.HandleCardClick(card);
            EventBus.RaiseCardClicked(card);
        }

        void OnCardMatch(ICard a, ICard b)
        {
            Debug.Log("Match: " + a.ID);
        }

        void OnMismatch(ICard a, ICard b)
        {
            Debug.Log("No Match.");
        }

        void OnLevelComplete()
        {
            Debug.Log("Level Complete");
            // Load next
        }
    }
}
