using DG.Tweening;
using UnityEngine;

namespace GCP.UI.MainMenu
{
    public class MovingPanel : MonoBehaviour
    {
        public void MoveTo(RectTransform target)
        {
           transform.DOMove(target.position, 0.5f)
               .SetEase(Ease.InOutCubic);
        }
    }
}