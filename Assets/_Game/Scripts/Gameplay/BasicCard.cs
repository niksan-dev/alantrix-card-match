using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Niksan.CardGame
{
    public class BasicCard : MonoBehaviour, ICard
    {
        [SerializeField] private Image frontImage; 
        [SerializeField] private GameObject frontRoot; // parent of front face
        [SerializeField] private GameObject backRoot;  // parent of back face
        [SerializeField] private float flipDuration = 0.25f;

        private CardData data;
        private bool isFlipped = false;
        public bool IsFlipped => isFlipped;
       
        public int ID => data?.id ?? -1;

        public void SetData(CardData cardData)
        {
            this.data = cardData;
            frontImage.sprite = cardData.faceSprite;
            this.GetComponent<CardInput>().Initialize(this);
            HideInstant(); // Start hidden
        }

        private void Awake()
        {
           // btnCard.onClick.AddListener(OnClicked);
        }

        public void OnClicked()
        {
           
        }

        public void Reveal()
        {
            if (isFlipped) return;
            StartCoroutine(Flip(true));
        }

        public void Hide()
        {
            if (!isFlipped) return;
            StartCoroutine(Flip(false));
        }

        private void HideInstant()
        {
            isFlipped = false;
            frontRoot.SetActive(false);
            backRoot.SetActive(true);
        }

        public IEnumerator Flip(bool showFront)
        {
            isFlipped = showFront;

            float elapsed = 0f;
            float half = flipDuration / 2f;

            // Shrink
            yield return ScaleXOverTime(1f, 0f, half);

            // Mid-point: Swap sides
            transform.localScale = new Vector3(0f, 1f, 1f);
            frontRoot.SetActive(showFront);
            backRoot.SetActive(!showFront);

            // Expand
            yield return ScaleXOverTime(0f, 1f, half);
        }
        
        private IEnumerator ScaleXOverTime(float from, float to, float duration)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float scale = Mathf.Lerp(from, to, elapsed / duration);
                transform.localScale = new Vector3(scale, 1f, 1f);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Ensure final scale is exactly set
            transform.localScale = new Vector3(to, 1f, 1f);
        }
    }

}
