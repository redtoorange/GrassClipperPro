using UnityEngine;
using UnityEngine.UI;

namespace GCP.UI.HUD.Health
{
    public class HealthBarSlot : MonoBehaviour
    {
        [SerializeField] private Sprite fullHeart;
        [SerializeField] private Sprite halfHeart;
        [SerializeField] private Sprite emptyHeart;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetFull()
        {
            image.sprite = fullHeart;
        }

        public void SetHalf()
        {
            image.sprite = halfHeart;
        }

        public void SetEmpty()
        {
            image.sprite = emptyHeart;
        }
    }
}