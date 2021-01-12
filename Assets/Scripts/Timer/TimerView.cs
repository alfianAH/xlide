﻿using Effect;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private GameObject gameOver;
        [Range(0, 59)]
        [SerializeField] private int defaultMinutes, 
            defaultSeconds;
        [SerializeField] private CanvasGroup warningCanvasGroup;
        [SerializeField] private GameObject preparationPanel;
        [SerializeField] private Text timerText;
        
        private TimerModel timerModel;
        private bool isCountingDown;
        private float startAlpha;

        #region GETTER_SETTER

        public bool IsCountingDown
        {
            set => isCountingDown = value;
        }

        #endregion

        #region MONOBEHAVIOUR_METHODS
        
        // Start is called before the first frame update
        private void Start()
        {
            startAlpha = warningCanvasGroup.alpha;
            preparationPanel.SetActive(true);
            
            timerModel = new TimerModel
            {
                Minutes = defaultMinutes,
                Seconds = defaultSeconds
            };
            UpdateTimerText();
        }
        
        // Update is called once per frame
        private void Update()
        {
            timerModel.CountDown(isCountingDown, () =>
            {
                isCountingDown = false;
                gameOver.SetActive(true);
            }, UpdateTimerText);
            
            // If time is 00:10, then give warning effect
            if (timerModel.Seconds <= 10 && timerModel.Minutes == 0)
            {
                EffectScript.FadeEffect(warningCanvasGroup, startAlpha, 
                    timerModel.Milliseconds, 1);
            }
        }
        
        #endregion

        #region PRIVATE_METHODS
        
        /// <summary>
        /// Update timer text in UI
        /// </summary>
        private void UpdateTimerText()
        {
            timerText.text = timerModel.Seconds <= 15 && timerModel.Minutes == 0
                ? $"{timerModel.Seconds + timerModel.Milliseconds:F}" 
                : $"{timerModel.Minutes:00} : {timerModel.Seconds:00}";
        }
        
        #endregion

        #region PUBLIC_METHODS
        
        /// <summary>
        /// Add time
        /// </summary>
        /// <param name="value">Time in seconds</param>
        public void AddTime(int value)
        {
            timerModel.AddTime(value);
            UpdateTimerText();
        }
        
        #endregion
    }
}
