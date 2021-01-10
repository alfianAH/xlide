using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Effect
{
    public static class EffectScript
    {
        private static float maxAlpha = 1;
        
        /// <summary>
        /// Make fade effect continuously
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="startAlpha">Canvas Group start alpha</param>
        /// <param name="milliseconds">Millisecond 0-1</param>
        /// <param name="fadeDuration">Fade duration</param>
        public static void FadeEffect(CanvasGroup canvasGroup, float startAlpha, 
            float milliseconds, float fadeDuration)
        {
            // Change current alpha
            float canvasGroupAlpha = Mathf.MoveTowards(startAlpha, maxAlpha, 
                milliseconds / fadeDuration);
            canvasGroup.alpha = canvasGroupAlpha;
            
            // Change maxAlpha
            if (canvasGroupAlpha >= 1) maxAlpha = 0;
            if (canvasGroupAlpha <= 0) maxAlpha = 1;
        }
        
        /// <summary>
        /// Add number by units, tens, and so on
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="targetNumber"></param>
        /// <param name="numberText"></param>
        /// <param name="delaySeconds"></param>
        /// <returns></returns>
        public static IEnumerator AddNumber(int currentNumber, int targetNumber, 
            Text numberText, float delaySeconds)
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
    }
}
