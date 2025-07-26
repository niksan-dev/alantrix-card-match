using UnityEngine;

namespace Niksan.CardGame
{

    public interface ICard : IFlippable, IRevealable
    {
        int ID { get; }
        void SetData(CardData data);
        void OnClicked();
    }
}
