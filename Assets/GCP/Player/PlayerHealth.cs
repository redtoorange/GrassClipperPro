using System;
using GCP.UI.Health;
using UnityEngine;

namespace GCP.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public Action OnPlayerDied;

        private HealthBar healthBar;

        [SerializeField] private int maxHealth = 3;
        private int currentHealth;

        private void Start()
        {
            healthBar = FindObjectOfType<HealthBar>();
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                OnPlayerDied?.Invoke();
            }
        }
    }
}