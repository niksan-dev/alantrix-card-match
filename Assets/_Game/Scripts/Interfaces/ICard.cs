using UnityEngine;
using Niksan.CardGame.Data;
namespace Niksan.CardGame
{

    public interface ICard : IFlippable, IRevealable
    {
        int ID { get; }
        void SetData(CardData data);
        void OnClicked();
    }
}
