using System;
using UnityEngine;

namespace GCP.UI.PauseMenu
{
    public class PauseMenuButtonPanel : MonoBehaviour
    {
        public Action OnResumeClicked;
        public Action OnRestartClicked;
        public Action OnSettingsClicked;
        public Action OnQuitClicked;

        public void HandleResumeClicked()
        {
            OnResumeClicked?.Invoke();
        }

        public void HandleRestartClicked()
        {
            OnRestartClicked?.Invoke();
        }

        public void HandleSettingsClicked()
        {
            OnSettingsClicked?.Invoke();
        }

        public void HandleQuitClicked()
        {
            OnQuitClicked?.Invoke();
        }
    }
}