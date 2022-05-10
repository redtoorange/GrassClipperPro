using UnityEngine;

namespace GCP.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerHealth playerHealth;
        private PlayerAudioController playerAudioController;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerHealth = GetComponent<PlayerHealth>();
            playerAudioController = GetComponent<PlayerAudioController>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
        }
    }
}