using System.Collections;
using TMPro;
using UnityEngine;

namespace Effect
{
    public static class AddNumberEffect
    {
        /// <summary>
        /// Add number by units, tens, and so on
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="targetNumber"></param>
        /// <param name="numberText"></param>
        /// <param name="delaySeconds"></param>
        /// <returns></returns>
        public static IEnumerator AddNumber(int currentNumber, int targetNumber, 
            TextMeshProUGUI numberText, float delaySeconds)
        {
            while (true)
            {
                int difference = targetNumber - currentNumber;
                int increment = NumberIncrement(difference);
                
                currentNumber += increment;
                numberText.text = currentNumber.ToString();
                
                if(currentNumber == targetNumber) break;
                yield return new WaitForSeconds(delaySeconds);
            }
        }
        
        #region PRIVATE_METHODS
        
        /// <summary>
        /// Set increment of units, tens, and so on
        /// </summary>
        /// <param name="difference"></param>
        /// <returns></returns>
        private static int NumberIncrement(int difference)
        {
            int increment = 1;
            if (difference > 10)
            {
                while (true)
                {
                    increment *= 10;
                    if (difference / increment < increment) break;
                }
            }
            return increment;
        }
        
        #endregion
    }
}