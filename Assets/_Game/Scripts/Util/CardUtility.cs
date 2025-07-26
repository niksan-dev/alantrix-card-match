using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;
using Niksan.CardGame.Data;

namespace Niksan.CardGame.Utils
{
    public static class CardUtility
    {
        public static List<CardData> GenerateShuffledPairs(Sprite[] availableFaces, int pairCount)
        {
            if (availableFaces.Length < pairCount)
            {
                Debug.LogError("Not enough unique card faces to generate the requested pairs!");
                return new List<CardData>();
            }

            List<CardData> result = new List<CardData>();
            List<Sprite> shuffled = new List<Sprite>(availableFaces);
            Shuffle(shuffled);

            for (int i = 0; i < pairCount; i++)
            {
                var sprite = shuffled[i];
                var dataA = new CardData(i, sprite);
                var dataB = new CardData(i, sprite); // Duplicate with same ID

                result.Add(dataA);
                result.Add(dataB);
            }

            Shuffle(result);
            return result;
        }

        private static void Shuffle<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}

[System.Serializable]
public class CardData
{
    public int id;
    public Sprite faceSprite;

    public CardData(int id, Sprite sprite)
    {
        this.id = id;
        this.faceSprite = sprite;
    }
}