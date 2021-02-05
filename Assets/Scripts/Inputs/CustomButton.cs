using Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inputs
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler
    {
        private AudioManager audioManager;
        
        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            audioManager.Play(ListSound.ButtonClick);
        }
    }
}