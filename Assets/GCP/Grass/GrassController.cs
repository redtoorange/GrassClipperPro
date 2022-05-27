using System;
using System.Collections.Generic;
using GCP.UI;
using GCP.UI.HUD;
using UnityEngine;

namespace GCP.Grass
{
    public class GrassController : MonoBehaviour
    {
        public Action OnGameWon;

        private AudioSource audioSource;
        private List<GrassClump> ownedGrass;
        private GrassCounter grassCounter;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            ownedGrass = new List<GrassClump>();
            foreach (GrassClump grassClump in GetComponentsInChildren<GrassClump>())
            {
                ownedGrass.Add(grassClump);
                grassClump.OnGrassCut += HandleGrassCut;
            }

            grassCounter = FindObjectOfType<GrassCounter>();
            grassCounter.SetCount(ownedGrass.Count);
        }

        private void HandleGrassCut(GrassClump clump)
        {
            audioSource.Play();
            ownedGrass.Remove(clump);
            grassCounter.SetCount(ownedGrass.Count);

            if (ownedGrass.Count == 0)
            {
                OnGameWon?.Invoke();
            }
        }
    }
}