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
        
        private TimerModel timerModel;
        private Text timerText;
        private bool isCountingDown;

        #region MONOBEHAVIOUR_METHODS
        
        // Start is called before the first frame update
        private void Start()
        {
            timerText = GetComponent<Text>();
            
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
