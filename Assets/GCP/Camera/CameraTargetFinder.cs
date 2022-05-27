using Cinemachine;
using GCP.Player;
using UnityEngine;

namespace GCP.Camera
{
    public class CameraTargetFinder : MonoBehaviour
    {
        private PlayerController playerController;
        private CinemachineVirtualCamera virtualCamera;

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            
            virtualCamera.Follow = playerController.transform;
            virtualCamera.LookAt = playerController.transform;
        }
    }
}