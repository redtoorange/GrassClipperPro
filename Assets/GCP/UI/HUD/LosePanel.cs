using System;
using TMPro;
using UnityEngine;

namespace GCP.UI
{
    public class LosePanel : MonoBehaviour
    {
        [Header("Lose Text")]
        [SerializeField] private TMP_Text loseLabel;
        [SerializeField] private string loseText;
        
        [Header("Retry Button")]
        [SerializeField] private TMP_Text retryButtonLabel;
        [SerializeField] private string retryButtonText;
        
        [Header("Quit Button")]
        [SerializeField] private TMP_Text quitButtonLabel;
        [SerializeField] private string quitButtonText;
        
        public Action OnResetGameClicked;
        public Action OnQuitGameClicked;

        private void Awake()
        {
            loseLabel.SetText(loseText);
            retryButtonLabel.SetText(retryButtonText);
            quitButtonLabel.SetText(quitButtonText);
        }

        public void ResetGame()
        {
            OnResetGameClicked?.Invoke();
        }

        public void QuitGame()
        {
            OnQuitGameClicked?.Invoke();
        }
    }
}