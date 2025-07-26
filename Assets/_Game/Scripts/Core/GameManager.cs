using System.Collections;
using System.Collections.Generic;
using Niksan.CardGame.Data;
using Niksan.UI;
using UnityEngine;

namespace Niksan.CardGame
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private ProgressionManager progressionManager;
        [SerializeField] private BoardGenerator boardGenerator;
        [SerializeField] private MatchFinder matchFinder;
        [SerializeField] private List<LevelConfig> levels;
        private int totalCards;
        public int currentLevel = 0;
        public int maxLevels => levels.Count;
        void Awake()
        {
            Instance = this;
            InitProgressionManager();
        }

        void InitProgressionManager()
        {
            progressionManager.Initialize(maxLevels);
            currentLevel = progressionManager.LoadScoreAndLevel().currentLevel;
        }

        public void StartGame()
        {
            if (currentLevel >= maxLevels)
            {
                Debug.LogError("No More Levels Available");
                return;
            }
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
        private void HandleLevelComplete()
        { 
            Debug.Log("Level Done!");
            progressionManager.SaveScoreAndLevel(currentLevel,scoreManager.CurrentScore);
            StartCoroutine(DelayToShowGameOver());
        }

        IEnumerator DelayToShowGameOver()
        {
            yield return new WaitForSeconds(2);
            UIManager.Instance.ShowGameOver();
        }
        private void HandleCardFlip(ICard card) => Debug.Log("Card Flipped: " + card.ID);

        public void OnCardClicked(ICard card)
        {
            //matchFinder.HandleCardClick(card);
            EventBus.RaiseCardClicked(card);
            SoundManager.instance.PlaySound(SoundType.FLIP);
        }

        void OnCardMatch(ICard a, ICard b)
        {
            Debug.Log("Match: " + a.ID);
            SoundManager.instance.PlaySound(SoundType.MATCH);
        }

        void OnMismatch(ICard a, ICard b)
        {
            Debug.Log("No Match.");
            SoundManager.instance.PlaySound(SoundType.MISMATCH);
        }

        void OnLevelComplete()
        {
            Debug.Log("Level Compl  ete");
            // Load next
        }
    }
}
