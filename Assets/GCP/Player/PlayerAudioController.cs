using UnityEngine;

namespace GCP.Player
{
    public class PlayerAudioController : MonoBehaviour
    {
        private enum AudioState
        {
            STOPPED,
            IDLE,
            THROTTLE,
        }

        [SerializeField] private float throttlePitch = 2.0f;
        [SerializeField] private float idlePitch = 1.0f;
        [SerializeField] private float stoppedPitch = 0.0f;

        [SerializeField] private float maxIdleTime = 1.0f;
        [SerializeField] private float idleDeadZone = 0.1f;

        private AudioSource audioSource;
        private PlayerMovement playerMovement;

        private AudioState currentState = AudioState.STOPPED;

        private float elapsed = 0.0f;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            audioSource = GetComponentInChildren<AudioSource>();
        }

        private void Update()
        {
            float currentInput = Mathf.Abs(playerMovement.GetSpeed());

            // Stopped --> Throttle
            if (currentState == AudioState.STOPPED && currentInput > idleDeadZone)
            {
                audioSource.Play();
                currentState = AudioState.THROTTLE;
                audioSource.pitch = throttlePitch;
            }
            else if (currentState == AudioState.THROTTLE && currentInput < idleDeadZone)
            {
                currentState = AudioState.IDLE;
                audioSource.pitch = idlePitch;
                elapsed = 0.0f;
            }
            else if (currentState == AudioState.IDLE)
            {
                if (currentInput > idleDeadZone)
                {
                    currentState = AudioState.THROTTLE;
                    audioSource.pitch = throttlePitch;
                }
                else
                {
                    elapsed += Time.deltaTime;
                    if (elapsed >= maxIdleTime)
                    {
                        currentState = AudioState.STOPPED;
                        audioSource.pitch = stoppedPitch;
                        audioSource.Stop();
                    }
                }
            }
        }
    }
}