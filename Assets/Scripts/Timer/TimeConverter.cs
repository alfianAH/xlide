using System.Collections;

namespace Timer
{
    public static class TimeConverter
    {
        /// <summary>
        /// Convert seconds to list of time, such as minutes, hours, etc
        /// </summary>
        /// <param name="value">Time in seconds</param>
        /// <returns></returns>
        public static ArrayList SecondsToArrayList(int value)
        {
            int minutes = value / 60;
            value -= minutes * 60;
            int seconds = value;
            
            return new ArrayList
            {
                seconds, minutes
            };
        }
    }
}