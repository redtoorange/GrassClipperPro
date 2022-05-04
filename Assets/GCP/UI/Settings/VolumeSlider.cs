using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GCP.UI.Settings
{
    public class VolumeSlider : MonoBehaviour
    {
        public static Action<string> OnAudioUpdated;

        [SerializeField] private Slider volumeSlider;
        [SerializeField] private TMP_InputField volumeInputField;
        [SerializeField] private string volumeTarget = "MasterVolume";

        private int value = 100;

        private void Start()
        {
            if (PlayerPrefs.HasKey(volumeTarget))
            {
                value = PlayerPrefs.GetInt(volumeTarget);
            }
            else
            {
                SetPlayerPref();
            }

            volumeSlider.value = value;
            volumeSlider.onValueChanged.AddListener(HandleOnSliderValueChanged);
            volumeInputField.text = value.ToString();
            volumeInputField.onValueChanged.AddListener(HandleOnInputValueChanged);
        }

        private void SetPlayerPref()
        {
            PlayerPrefs.SetInt(volumeTarget, value);
            PlayerPrefs.Save();
            OnAudioUpdated?.Invoke(volumeTarget);
        }

        private void HandleOnInputValueChanged(string newValue)
        {
            if (int.TryParse(newValue, out int result))
            {
                value = Mathf.Clamp(result, 0, 100);
                volumeSlider.value = value;
                SetPlayerPref();
            }
            else
            {
                volumeInputField.text = value.ToString();
            }
        }

        private void HandleOnSliderValueChanged(float newValue)
        {
            value = (int)newValue;
            volumeInputField.text = value.ToString();
            SetPlayerPref();
        }
    }
}