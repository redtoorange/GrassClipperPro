using GCP.Orchestration;
using UnityEngine;

namespace GCP.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private RectTransform leftTarget;
        [SerializeField] private RectTransform middleTarget;
        [SerializeField] private RectTransform rightTarget;

        private MainMenuMain mainButtonPanel;
        private MovingPanel mainButtonPanelMover;
        private SettingsMenu menuPanel;
        private MovingPanel settingsMenuPanelMover;
        private LevelManager levelManager;

        private void Start()
        {
            levelManager = FindObjectOfType<LevelManager>();

            mainButtonPanel = GetComponentInChildren<MainMenuMain>();
            mainButtonPanel.OnNewGamePressed += levelManager.NextLevel;
            mainButtonPanel.OnSettingsPressed += TransitionToSettings;
            mainButtonPanel.OnQuitGamePressed += levelManager.QuitGame;

            mainButtonPanelMover = mainButtonPanel.GetComponent<MovingPanel>();

            menuPanel = GetComponentInChildren<SettingsMenu>();
            menuPanel.OnCancelClicked += TransitionToMainMenu;

            settingsMenuPanelMover = menuPanel.GetComponent<MovingPanel>();
        }

        public void TransitionToSettings()
        {
            mainButtonPanelMover.MoveTo(leftTarget);
            settingsMenuPanelMover.MoveTo(middleTarget);
        }

        public void TransitionToMainMenu()
        {
            mainButtonPanelMover.MoveTo(middleTarget);
            settingsMenuPanelMover.MoveTo(rightTarget);
        }
    }
}