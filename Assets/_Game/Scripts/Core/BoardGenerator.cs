using System.Collections.Generic;
using Niksan.CardGame.Data;
using Niksan.CardGame.Utils;
using UnityEngine;
using UnityEngine.UI;
namespace Niksan.CardGame
{

    public class BoardGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private RectTransform boardPanel;
        [SerializeField] private GridLayoutGroup gridLayout;
        private float hudHeight = 150;
        public void GenerateBoard(LevelConfig config)
        {
            ClearBoard();
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = config.columns;
           // gridLayout.padding = new RectOffset(50, 50, 50, 50);
            int total = config.rows * config.columns;
            float panelWidth = boardPanel.rect.width - gridLayout.padding.left - gridLayout.padding.right - (gridLayout.spacing.x*config.columns-1);
            float panelHeight = boardPanel.rect.height - gridLayout.padding.top - gridLayout.padding.bottom- (gridLayout.spacing.y*config.rows-1);

            float cellWidth = panelWidth / config.columns;
            float cellHeight = panelHeight / config.rows;
            float size = Mathf.Min(cellWidth, cellHeight);
            
            gridLayout.cellSize = new Vector2(size, size);
            // Instantiate shuffled pairs of cards
            var pairs = CardUtility.GenerateShuffledPairs(config.cardFaces, total / 2);
            foreach (var face in pairs)
            {
                var cardGO = Instantiate(cardPrefab, boardPanel);
                cardGO.GetComponent<ICard>().SetData(face);
            }
        }

        private void ClearBoard()
        {
            foreach (Transform child in boardPanel)
                Destroy(child.gameObject);
        }
    }
 
}
