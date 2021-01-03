using System;
using System.Collections;

namespace Timer
{
    [Serializable]
    public class TimerModel
    {
        private float milliseconds;
        private int seconds, minutes;
        
        public float Milliseconds
        {
            get => milliseconds;
            set => milliseconds = value;
        }
        
        public int Seconds
        {
            get => seconds;
            set => seconds = value;
        }
        
        public int Minutes
        {
            get => minutes;
            set => minutes = value;
        }
        
        /// <summary>
        /// Count down
        /// </summary>
        /// <param name="timeIsUp">Events after time is up</param>
        public void CountDown(Action timeIsUp)
        {
            if (milliseconds >= 1.0f)
            {
                milliseconds -= 1.0f;
            
                // If time is not up, ...
                if (seconds > 0 || minutes > 0)
                {
                    seconds--; // Decrease seconds
                    if (seconds < 0.0f)
                    {
                        seconds = 59; // Repeat seconds
                        minutes--; // Decrease minutes;
                    }
                }
                else // If time is up, ...
                {
                    timeIsUp();
                }
            }
        }

        /// <summary>
        /// Convert value and add time
        /// </summary>
        /// <param name="value">Time in seconds</param>
        public void AddTime(int value)
        {
            ArrayList timeConverter = TimeConverter.SecondsToArrayList(value);
            
            seconds += (int) timeConverter[0];
            minutes += (int) timeConverter[1];
        }
    }
}
