using UnityEngine;

namespace Niksan.CardGame.Data
{
    [CreateAssetMenu(menuName = "CardGame/Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Grid Settings")]
        [Range(2, 8)] public int rows = 2;
        [Range(2, 8)] public int columns = 2;

        [Header("Card Settings")]
        [Tooltip("Faces to be randomly paired and distributed.")]
        public Sprite[] cardFaces;

        [Header("Optional Info")]
        public string levelID = "Level_1";
        public string displayName = "2 x 2";
        public Difficulty difficulty = Difficulty.Easy;

        public int TotalCards => rows * columns;

        public bool IsEvenPairCount => TotalCards % 2 == 0;
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Expert
    }
}