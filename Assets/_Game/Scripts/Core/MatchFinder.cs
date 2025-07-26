using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niksan.CardGame
{
    public class MatchFinder : MonoBehaviour
    {
        private Queue<ICard> flipQueue = new Queue<ICard>();
        private List<ICard> revealedCards = new List<ICard>();
        private HashSet<ICard> matchedCards = new HashSet<ICard>();

        public float checkDelay = 0.5f;

        private int totalCards;


        private void OnEnable()
        {
            EventBus.OnCardClicked += HandleCardClick;
        }

        private void OnDisable()
        {
            EventBus.OnCardClicked -= HandleCardClick;
        }

        public void Init(int total)
        {
            totalCards = total;
            revealedCards.Clear();
            matchedCards.Clear();
            flipQueue.Clear();
        }

         void HandleCardClick(ICard clicked)
        {
            if (clicked.IsFlipped || matchedCards.Contains(clicked)) return;

            clicked.Reveal();
            flipQueue.Enqueue(clicked);

            if (flipQueue.Count >= 2)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            while (flipQueue.Count >= 2)
            {
                ICard first = flipQueue.Dequeue();
                ICard second = flipQueue.Dequeue();

                yield return new WaitForSeconds(checkDelay);

                if (first.ID == second.ID)
                {
                    matchedCards.Add(first);
                    matchedCards.Add(second);
                    EventBus.RaiseCardsMatched(first, second);

                    if (matchedCards.Count >= totalCards)
                        EventBus.RaiseLevelCompleted();
                } 
                else
                {
                    first.Hide();
                    second.Hide();
                    EventBus.RaiseCardsMismatched(first, second);
                }
            }
        }

        public void ResetMatches()                                                                                                                                                                                                        
        {
            revealedCards.Clear();
            matchedCards.Clear();
            flipQueue.Clear();
        }
    }
}
