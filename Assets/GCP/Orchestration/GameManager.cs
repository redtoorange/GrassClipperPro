using GCP.Grass;
using GCP.Player;
using GCP.Timer;
using GCP.UI;
using UnityEngine;

namespace GCP.Orchestration
{
    public class GameManager : MonoBehaviour
    {
        // Level
        [SerializeField] private LevelManager levelManager;

        // UI
        [SerializeField] private WonPanel wonPanel;
        [SerializeField] private LosePanel losePanel;

        // Game World
        private GrassController grassController;

        // PlayerController
        private PlayerController playerController;
        private PlayerMovement playerMovement;
        private PlayerHealth playerHealth;

        [SerializeField] private TimerManager timerManager;

        private void Start()
        {
            wonPanel.OnNextLevelClicked += levelManager.NextLevel;
            losePanel.OnQuitGameClicked += levelManager.LoadMainMenu;
            losePanel.OnResetGameClicked += levelManager.RestartLevel;

            grassController = FindObjectOfType<GrassController>();
            grassController.OnGameWon += HandleGameWon;

            playerController = FindObjectOfType<PlayerController>();
            playerMovement = playerController.GetComponent<PlayerMovement>();
            playerHealth = playerController.GetComponent<PlayerHealth>();
            playerHealth.OnPlayerDied += HandlePlayerDied;

            timerManager.OnTimerExpired += HandleTimeOut;
        }

        private void HandleTimeOut()
        {
            playerMovement.StopControl();
            losePanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }

        private void HandlePlayerDied()
        {
            playerMovement.StopControl();
            losePanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }

        private void HandleGameWon()
        {
            playerMovement.StopControl();
            wonPanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }
    }
}