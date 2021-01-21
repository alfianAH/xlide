using UnityEngine;
using UnityEngine.UI;

namespace Effect
{
    public class GroundEffect : MonoBehaviour
    {
        private static Image groundImage;
        
        // Start is called before the first frame update
        private void Start()
        {
            groundImage = GetComponent<Image>();
        }
        
        /// <summary>
        /// Change ground sprite
        /// </summary>
        /// <param name="groundSprite"></param>
        public static void ChangeGroundImage(Sprite groundSprite)
        {
            groundImage.sprite = groundSprite;
        }
    }
}
