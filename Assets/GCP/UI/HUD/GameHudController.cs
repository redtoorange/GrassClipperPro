using GCP.UI.Health;
using UnityEngine;

namespace GCP.UI
{
    public class GameHudController : MonoBehaviour
    {
        [SerializeField] private bool showHealth = true;
        [SerializeField] private bool showTimer = true;

        private WonPanel wonPanel;
        private LosePanel losePanel;
        private TimerUI timerUI;
        private HealthBar healthBar;

        private void Awake()
        {
            wonPanel = GetComponentInChildren<WonPanel>(true);
            losePanel = GetComponentInChildren<LosePanel>(true);
            timerUI = GetComponentInChildren<TimerUI>(true);
            healthBar = GetComponentInChildren<HealthBar>(true);
        }

        private void Start()
        {
            healthBar.gameObject.SetActive(showHealth);
            timerUI.gameObject.SetActive(showTimer);
        }

        // Getters
        public WonPanel GetWonPanel() => wonPanel;
        public LosePanel GetLosePanel() => losePanel;
    }
}