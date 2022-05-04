using System;
using UnityEngine;

namespace GCP.Grass
{
    public class GrassClump : MonoBehaviour
    {
        public Action<GrassClump> OnGrassCut;

        public void Cut()
        {
            OnGrassCut?.Invoke(this);
            Destroy(gameObject);
        }
    }
}