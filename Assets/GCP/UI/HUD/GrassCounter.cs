using TMPro;
using UnityEngine;

namespace GCP.UI
{
    public class GrassCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text grassCountLabel;

        public void SetCount(int count)
        {
            grassCountLabel.SetText(count.ToString());
        }
    }
}