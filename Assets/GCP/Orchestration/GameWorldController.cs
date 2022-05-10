using GCP.Flower;
using GCP.Grass;
using GCP.Player;
using UnityEngine;

namespace GCP.Orchestration
{
    public class GameWorldController : MonoBehaviour
    {
        private GrassController grassController;
        private FlowerController flowerController;
        private PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponentInChildren<PlayerController>();
            grassController = GetComponentInChildren<GrassController>();
            flowerController = GetComponentInChildren<FlowerController>();
        }

        public PlayerController GetPlayerController() => playerController;
        public GrassController GetGrassController() => grassController;
        public FlowerController GetFlowerController() => flowerController;
    }
}