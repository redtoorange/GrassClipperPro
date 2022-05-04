using GCP.Player;
using GCP.Timer;
using UnityEngine;

namespace GCP.Utility
{
    public class StopTimerBox : MonoBehaviour
    {
        [SerializeField] private GameObject postProcessingVolume;
        [SerializeField] private TimerManager timerManager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                timerManager.StopTimer();
                timerManager.HideTimer();
                postProcessingVolume.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                Transform playerTransform = playerController.transform;
                Vector2 direction = playerTransform.position - transform.position;

                // Player if above, do nothing
                if (direction.y < 0)
                {
                    timerManager.ResumeTimer();
                    timerManager.ShowTimer();
                    postProcessingVolume.gameObject.SetActive(false);
                }
            }
        }
    }
}