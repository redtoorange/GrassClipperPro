using System.Collections.Generic;
using GCP.Grass;
using UnityEngine;

namespace GCP.Player.Mower
{
    public class MowerController : MonoBehaviour
    {
        [SerializeField] private List<ParticleSystem> grassParticleSystems;
        [SerializeField] private List<ParticleSystem> flowerParticleSystems;

        public enum MowerCuttingState
        {
            Cutting,
            NotCutting
        }

        private MowerCuttingState currentCuttingState = MowerCuttingState.NotCutting;

        public void Start()
        {
            PlayerMovement playerMovement = GetComponentInParent<PlayerMovement>();
            playerMovement.OnStartMower += HandleStartMower;
            playerMovement.OnStopMower += HandleStopMower;
        }

        private void HandleStartMower()
        {
            currentCuttingState = MowerCuttingState.Cutting;
        }

        private void HandleStopMower()
        {
            currentCuttingState = MowerCuttingState.NotCutting;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (currentCuttingState == MowerCuttingState.NotCutting) return;

            if (other.TryGetComponent(out GrassClump gc))
            {
                CutGrass(gc);
            }
            else if (other.TryGetComponent(out Flower.Flower flower))
            {
                CutFlowers(flower);
            }
        }

        private void CutGrass(GrassClump gc)
        {
            gc.Cut();
            foreach (ParticleSystem system in grassParticleSystems)
            {
                system.Play();
            }
        }

        private void CutFlowers(Flower.Flower flower)
        {
            flower.Cut();
            foreach (ParticleSystem system in flowerParticleSystems)
            {
                system.Play();
            }
        }
    }
}