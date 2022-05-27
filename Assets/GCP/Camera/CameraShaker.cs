using Cinemachine;
using UnityEngine;

namespace GCP.Camera
{
    public class CameraShaker : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin noise;

        [SerializeField] private float shakeAmplitudeGain = 1.0f;
        [SerializeField] private float shakeFrequencyGain = 1.0f;
        [SerializeField] private float shakeDuration = 0.25f;
        private float elapsed;
        private bool shaking = false;

        private void Start()
        {
            virtualCamera = FindObjectOfType<GameCamera>().GetComponent<CinemachineVirtualCamera>();
            noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            if (shaking)
            {
                elapsed += Time.deltaTime;
                if (elapsed >= shakeDuration)
                {
                    elapsed = 0;
                    shaking = false;
                    noise.m_AmplitudeGain = 0;
                    noise.m_FrequencyGain = 0;
                }
            }
        }

        public void ShakeCamera()
        {
            noise.m_AmplitudeGain = shakeAmplitudeGain;
            noise.m_FrequencyGain = shakeFrequencyGain;
            elapsed = 0.0f;
            shaking = true;
        }
    }
}