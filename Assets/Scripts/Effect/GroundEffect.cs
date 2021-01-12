using UnityEngine;
using UnityEngine.UI;

namespace Effect
{
    public class GroundEffect : MonoBehaviour
    {
        [SerializeField] private Sprite[] groundSprites;
        
        private Image groundImage;
        // private Animator groundAnimator;
        
        // Start is called before the first frame update
        private void Start()
        {
            groundImage = GetComponent<Image>();
            // groundAnimator = GetComponent<Animator>();
        }
        
        /// <summary>
        /// Play ground animation and change ground sprite
        /// </summary>
        /// <param name="groundSpriteIndex">The correct box index</param>
        public void PlayGroundAnimation(int groundSpriteIndex)
        {
            groundImage.sprite = groundSprites[groundSpriteIndex];
            // groundAnimator.SetTrigger("PlayAnim");
        }
    }
}
