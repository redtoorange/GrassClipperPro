using System.Collections.Generic;
using GCP.Player;
using GCP.Utility;
using UnityEngine;

namespace GCP.Flower
{
    public class FlowerController : MonoBehaviour
    {
        private List<Flower> ownedFlowers;
        private PlayerHealth playerHealth;
        private AudioSource audioSource;

        private CameraShaker cameraShaker;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            cameraShaker = GetComponent<CameraShaker>();
            playerHealth = FindObjectOfType<PlayerHealth>();

            ownedFlowers = new List<Flower>();
            foreach (Flower grassClump in GetComponentsInChildren<Flower>())
            {
                ownedFlowers.Add(grassClump);
                grassClump.OnFlowerCut += HandleFlowerCut;
            }
        }

        private void HandleFlowerCut(Flower flower)
        {
            audioSource.Play();
            cameraShaker.ShakeCamera();

            ownedFlowers.Remove(flower);
            playerHealth.TakeDamage(1);
        }
    }
}