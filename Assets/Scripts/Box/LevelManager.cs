using UnityEngine;

namespace Box
{
    public class LevelManager : MonoBehaviour
    {
        public int similarityLimit;
        private int similarity;
        
        /// <summary>
        /// Check similarity until similarityLimit
        /// </summary>
        /// <param name="randomValue">Box that want to be spawned</param>
        /// <param name="previousValue">The previous box</param>
        /// <returns>
        /// Return true when similarity == similarityLimit
        /// Return false when similarity != similarityLimit or
        /// randomValue != targetValue
        /// </returns>
        public bool IsSimilarLimit(int randomValue, int previousValue)
        {
            if (randomValue == previousValue)
            {
                similarity += 1;
                
                if (similarity == similarityLimit)
                {
                    // Reset similarity after hits the limit
                    similarity = 0;
                    return true;
                }
                
                return false;
            }
            
            // Reset similarity because randomValue != previousValue anymore
            similarity = 0;
            return false;
        }
    }
}