using GCP.Timer;
using GCP.UI;
using UnityEngine;

namespace GCP.Orchestration
{
    public class ManagerController : MonoBehaviour
    {
        // Internal
        private GameManager gameManager;
        private TimerManager timerManager;
        private LevelManager levelManager;

        // External
        private GameWorldController gameWorldController;
        private GameHudController gameHudController;

        private void Awake()
        {
            // Internal
            gameManager = GetComponentInChildren<GameManager>(true);
            timerManager = GetComponentInChildren<TimerManager>(true);
            levelManager = GetComponentInChildren<LevelManager>(true);

            // External
            gameWorldController = FindObjectOfType<GameWorldController>();
            gameHudController = FindObjectOfType<GameHudController>();
        }

        private void Start()
        {
            gameManager.Initialize(
                gameHudController,
                levelManager,
                timerManager,
                gameWorldController
            );
        }
    }
}