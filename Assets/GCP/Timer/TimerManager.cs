using System;
using GCP.UI;
using UnityEngine;

namespace GCP.Timer
{
    public class TimerManager : MonoBehaviour
    {
        public Action OnTimerExpired;
        
        [SerializeField] private TimerUI timerUi;
        [SerializeField] private bool levelHasTimer;
        [SerializeField] private float levelTime = 10.0f;
        private void Start()
        {
            if (!levelHasTimer)
            {
                timerUi.gameObject.SetActive(false);
            }
            else
            {
                timerUi.OnTimerExpired += HandleTimerUIDone;
                timerUi.SetLevelTime(levelTime);
                timerUi.Start();
            }
        }

        private void HandleTimerUIDone()
        {
            OnTimerExpired?.Invoke();
        }

        public void StopTimer()
        {
            if (levelHasTimer)
            {
                timerUi.Stop();
            }
        }

        public void HideTimer()
        {
            if (levelHasTimer)
            {
                timerUi.gameObject.SetActive(false);
            }
        }

        public void ResumeTimer()
        {
            if (levelHasTimer)
            {
                timerUi.Resume();
            }
        }

        public void ShowTimer()
        {
            if (levelHasTimer)
            {
                timerUi.gameObject.SetActive(true);
            }
        }
    }
}