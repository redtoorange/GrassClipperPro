using System;
using UnityEngine;

namespace GCP.UI.MainMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        public Action OnSaveClicked;
        public Action OnCancelClicked;

        public void SavePressed()
        {
            OnSaveClicked?.Invoke();
        }

        public void CancelPressed()
        {
            OnCancelClicked?.Invoke();
        }
    }
}