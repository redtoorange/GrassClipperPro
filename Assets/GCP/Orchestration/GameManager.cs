using GCP.Grass;
using GCP.Player;
using GCP.Timer;
using GCP.UI;
using GCP.UI.HUD;
using GCP.UI.Menus.PauseMenu;
using UnityEngine;

namespace GCP.Orchestration
{
    public class GameManager : MonoBehaviour
    {
        // UI
        private WonPanel wonPanel;
        private LosePanel losePanel;

        // PlayerController
        private PlayerMovement playerMovement;
        private PlayerHealth playerHealth;

        private TimerManager timerManager;

        public void Initialize(
            GameHudController gameHudController,
            LevelManager levelManager,
            TimerManager timerManager,
            GameWorldController gameWorldController
        )
        {
            wonPanel = gameHudController.GetWonPanel();
            wonPanel.OnNextLevelClicked += levelManager.NextLevel;

            losePanel = gameHudController.GetLosePanel();
            losePanel.OnQuitGameClicked += levelManager.LoadMainMenu;
            losePanel.OnResetGameClicked += levelManager.RestartLevel;

            this.timerManager = timerManager;
            this.timerManager.OnTimerExpired += HandleTimeOut;

            GrassController gc = gameWorldController.GetGrassController();
            gc.OnGameWon += HandleGameWon;

            PlayerController pc = gameWorldController.GetPlayerController();
            playerMovement = pc.GetComponent<PlayerMovement>();
            playerHealth = pc.GetComponent<PlayerHealth>();
            playerHealth.OnPlayerDied += HandlePlayerDied;

            PauseMenuController.OnPauseMenuHidden += HandleGameUnpaused;
            PauseMenuController.OnPauseMenuShown += HandleGamePaused;
        }

        private void HandleTimeOut()
        {
            playerMovement.EnableControl();
            losePanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }

        private void HandlePlayerDied()
        {
            playerMovement.EnableControl();
            losePanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }

        private void HandleGameWon()
        {
            playerMovement.EnableControl();
            wonPanel.gameObject.SetActive(true);
            timerManager.StopTimer();
        }

        private void HandleGamePaused()
        {
            playerMovement.EnableControl();
            timerManager.StopTimer();
        }
        
        private void HandleGameUnpaused()
        {
            playerMovement.EnableControl(true);
            timerManager.ResumeTimer();
        }
    }
}