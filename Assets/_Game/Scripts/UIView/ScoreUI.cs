using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Niksan.CardGame
{


    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text streakText;

        private void Awake()
        {
            EventBus.OnScoreUpdate += UpdateUI;
        }

        private void OnDestroy()
        {
            EventBus.OnScoreUpdate -= UpdateUI;
        }

        private void UpdateUI(int score, int streak)
        {
            scoreText.text = $"Score: {score}";
            streakText.text = $"Streak: {streak}";
        }
    }
}

