using System.Collections.Generic;
using GCP.Grass;
using UnityEngine;

namespace GCP.Player.Mower
{
    public class MowerController : MonoBehaviour
    {
        [SerializeField] private List<ParticleSystem> grassParticleSystems;
        [SerializeField] private List<ParticleSystem> flowerParticleSystems;

        private void OnTriggerEnter2D(Collider2D other)
        {
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