using UnityEngine;

namespace GCP.UI.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthBarSlot leftSlot;
        [SerializeField] private HealthBarSlot middleSlot;
        [SerializeField] private HealthBarSlot rightSlot;

        private void Start()
        {
            leftSlot.SetFull();
            middleSlot.SetFull();
            rightSlot.SetFull();
        }

        public void SetHealth(int amount)
        {
            if (amount == 3)
            {
                leftSlot.SetFull();
                middleSlot.SetFull();
                rightSlot.SetFull();
            }
            else if (amount == 2)
            {
                leftSlot.SetEmpty();
                middleSlot.SetFull();
                rightSlot.SetFull();
            }
            else if (amount == 1)
            {
                leftSlot.SetEmpty();
                middleSlot.SetEmpty();
                rightSlot.SetFull();
            }
            else
            {
                leftSlot.SetEmpty();
                middleSlot.SetEmpty();
                rightSlot.SetEmpty();
            }
        }
    }
}