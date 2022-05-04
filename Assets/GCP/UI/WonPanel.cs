﻿using System;
using TMPro;
using UnityEngine;

namespace GCP.UI
{
    public class WonPanel : MonoBehaviour
    {
        [Header("Won Label")]
        [SerializeField] private TMP_Text wonLabel;
        [SerializeField] private string labelText;
        
        [Header("Won Button")]
        [SerializeField] private TMP_Text wonButtonLabel;
        [SerializeField] private string buttonText;
        
        public Action OnNextLevelClicked;

        private void Start()
        {
            wonLabel.SetText(labelText);
            wonButtonLabel.SetText(buttonText);
        }

        public void NextLevel()
        {
            OnNextLevelClicked?.Invoke();
        }
    }
}