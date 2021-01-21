using TMPro;
using UnityEngine;

namespace Timer
{
    public class PreparationTimer : MonoBehaviour
    {
        [Range(0, 59)]
        [SerializeField] private int defaultMinutes, 
            defaultSeconds;
        [SerializeField] private TimerView timer;
        [SerializeField] private TextMeshProUGUI timerText;
        
        private TimerModel timerModel;
        private bool isCountingDown;

        #region MONOBEHAVIOUR_METHODS

        private void OnEnable()
        {
            isCountingDown = true;
            
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
                timer.IsCountingDown = true;
                gameObject.SetActive(false);
            }, UpdateTimerText);
        }
        
        #endregion

        #region PRIVATE_METHODS
        
        /// <summary>
        /// Update timer text in UI
        /// </summary>
        private void UpdateTimerText()
        {
            timerText.text = $"{timerModel.Seconds}";
        }
        
        #endregion
    }
}