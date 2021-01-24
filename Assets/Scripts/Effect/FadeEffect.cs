using UnityEngine;

namespace Effect
{
    public static class FadeEffect
    {
        private static float maxAlpha = 1;
        
        /// <summary>
        /// Make fade effect continuously
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="startAlpha">Canvas Group start alpha</param>
        /// <param name="milliseconds">Millisecond 0-1</param>
        /// <param name="fadeDuration">Fade duration</param>
        public static void Fade(CanvasGroup canvasGroup, float startAlpha, 
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
    }
}
