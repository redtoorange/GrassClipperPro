using System;
using UnityEngine;

namespace GCP.UI.MainMenu
{
    public class MainMenuMain : MonoBehaviour
    {
        public Action OnSettingsPressed;
        public Action OnNewGamePressed;
        public Action OnQuitGamePressed;

        public void NewGamePressed()
        {
            OnNewGamePressed?.Invoke();
        }

        public void SettingsPressed()
        {
            OnSettingsPressed?.Invoke();
        }

        public void QuitGamePressed()
        {
            OnQuitGamePressed?.Invoke();
        }
    }
}