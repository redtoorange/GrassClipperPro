using System;
using GCP.Orchestration;
using GCP.UI.MainMenu;
using UnityEngine;

namespace GCP.UI.PauseMenu
{
    public class PauseMenuController : MonoBehaviour
    {
        public static Action OnPauseMenuShown;
        public static Action OnPauseMenuHidden;

        [SerializeField] private LevelManager levelManager;
        [SerializeField] private RectTransform leftTarget;
        [SerializeField] private RectTransform middleTarget;
        [SerializeField] private RectTransform rightTarget;
        [SerializeField] private GameObject background;

        private PauseMenuButtonPanel menuButtons;
        private MovingPanel menuButtonsPanel;
        private SettingsMenu menu;
        private MovingPanel settingsMenuPanel;

        private bool shown;

        private void Awake()
        {
            menuButtons = GetComponentInChildren<PauseMenuButtonPanel>(true);
            menuButtonsPanel = menuButtons.GetComponent<MovingPanel>();

            menu = GetComponentInChildren<SettingsMenu>(true);
            settingsMenuPanel = menu.GetComponent<MovingPanel>();
        }

        private void Start()
        {
            menuButtons.OnResumeClicked += Hide;
            menuButtons.OnRestartClicked += levelManager.RestartLevel;
            menuButtons.OnSettingsClicked += TransitionToSettings;
            menuButtons.OnQuitClicked += levelManager.QuitGame;

            menu.OnCancelClicked += TransitionToButtons;
            menu.OnSaveClicked += TransitionToButtons;

            Hide();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (shown)
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            }
        }

        public void Show()
        {
            OnPauseMenuShown?.Invoke();

            background.SetActive(true);
            menuButtons.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            shown = true;
        }

        public void Hide()
        {
            background.SetActive(false);
            menuButtons.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            ResetPanels();
            OnPauseMenuHidden?.Invoke();
            shown = false;
        }

        public void TransitionToSettings()
        {
            menuButtonsPanel.MoveTo(leftTarget);
            settingsMenuPanel.MoveTo(middleTarget);
        }

        public void TransitionToButtons()
        {
            menuButtonsPanel.MoveTo(middleTarget);
            settingsMenuPanel.MoveTo(rightTarget);
        }

        private void ResetPanels()
        {
            menuButtonsPanel.transform.position = middleTarget.position;
            settingsMenuPanel.transform.position = rightTarget.position;
        }
    }
}