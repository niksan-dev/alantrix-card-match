using UnityEngine;

namespace Niksan.CardGame.Data
{
    [CreateAssetMenu(menuName = "CardGame/CardData")]
    public class CardData : ScriptableObject
    {
        public int id;
        public Sprite frontSprite;

        public CardData(int id, Sprite frontSprite)
        {
            this.id = id;
            this.frontSprite = frontSprite;
        }
    }
}