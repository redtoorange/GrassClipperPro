using System;
using UnityEngine;

namespace GCP.Flower
{
    public class Flower : MonoBehaviour
    {
        public Action<Flower> OnFlowerCut;

        public void Cut()
        {
            OnFlowerCut?.Invoke(this);
            Destroy(gameObject);
        }
    }
}