using UnityEngine;
using UnityEngine.EventSystems;

namespace Niksan.CardGame
{
    public class CardInput : MonoBehaviour,IPointerClickHandler
    {
        private ICard card;
        public void Initialize(ICard card)
        {
            this.card = card;
        }

        public void OnClick()
        {
            if (card.IsFlipped) return;
            EventBus.RaiseCardClicked(card);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }
    }

}
