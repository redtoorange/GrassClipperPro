using System;
using TMPro;
using UnityEngine;

namespace GCP.UI.HUD
{
    public class TimerUI : MonoBehaviour
    {
        public Action OnTimerExpired;

        
        [SerializeField] private float panicThreshold = 0.5f;
        [SerializeField] private float veryPanicThreshold = 0.1f;

        private float levelTime;
        private float currentTime;
        private bool running;

        private TMP_Text timerDisplay;
        private Animator animator;

        private static readonly int VERY_PANIC = Animator.StringToHash("VeryPanic");
        private static readonly int PANIC = Animator.StringToHash("Panic");

        private void Awake()
        {
            timerDisplay = GetComponentInChildren<TMP_Text>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!running) return;

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                if (currentTime < levelTime * veryPanicThreshold)
                {
                    animator.SetBool(VERY_PANIC, true);
                }
                else if (currentTime < levelTime * panicThreshold)
                {
                    animator.SetBool(PANIC, true);
                }

                if (currentTime <= 0)
                {
                    running = false;
                    currentTime = 0;
                    OnTimerExpired?.Invoke();
                }

                SetTimeLabelText(currentTime);
            }
        }

        private void SetTimeLabelText(float remainingTime)
        {
            timerDisplay.SetText(remainingTime.ToString("0.00") + " s");
        }

        public void SetLevelTime(float pLevelTime)
        {
            levelTime = pLevelTime;
            currentTime = levelTime;
        }
        
        public void Stop()
        {
            running = false;
            // animator.StopPlayback();
        }

        public void Start()
        {
            running = true;
        }

        public void Pause()
        {
            running = false;
            // animator.StopPlayback();
        }

        public void Resume()
        {
            running = true;
        }
    }
}