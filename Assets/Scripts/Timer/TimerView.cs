using Effect;
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
        
        private TimerModel timerModel;
        private Text timerText;
        private bool isCountingDown;
        private float startAlpha;

        #region MONOBEHAVIOUR_METHODS
        
        // Start is called before the first frame update
        private void Start()
        {
            timerText = GetComponent<Text>();
            startAlpha = warningCanvasGroup.alpha;
            isCountingDown = true;
            
            timerModel = new TimerModel
            {
                Minutes = defaultMinutes,
                Seconds = defaultSeconds
            };
        }
        
        // Update is called once per frame
        private void Update()
        {
            if (isCountingDown)
            {
                timerModel.Milliseconds += Time.deltaTime;
                
                timerModel.CountDown(() =>
                {
                    isCountingDown = false;
                    gameOver.SetActive(true);
                });
                
                UpdateTimerText();
                
                // If time is 0:10, then give warning effect
                if (timerModel.Seconds <= 10 && timerModel.Minutes == 0)
                {
                    EffectScript.FadeEffect(warningCanvasGroup, startAlpha, 
                        timerModel.Milliseconds, 1);
                }
            }
        }
        
        #endregion

        #region PRIVATE_METHODS
        
        /// <summary>
        /// Update timer text in UI
        /// </summary>
        private void UpdateTimerText()
        {
            timerText.text = $"{timerModel.Minutes:00} : {timerModel.Seconds:00}";
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
            isCountingDown = true;
            UpdateTimerText();
        }
        
        #endregion
    }
}
