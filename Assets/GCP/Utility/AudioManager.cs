using GCP.UI.Settings;
using UnityEngine;
using UnityEngine.Audio;

namespace GCP.Utility
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private float minValue = -30;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            VolumeSlider.OnAudioUpdated += UpdateVolumes;
        }

        private void UpdateVolumes(string which)
        {
            float convertedValue = (1.0f - (PlayerPrefs.GetInt(which) / 100.0f)) * minValue;
            audioMixer.SetFloat(which, convertedValue);
        }

        private void Start()
        {
            UpdateVolumes("MasterVolume");
            UpdateVolumes("MusicVolume");
            UpdateVolumes("EffectsVolume");
        }
    }
}