using UnityEngine;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        
        public AudioClip clip;
        
        [Range(0, 1)]
        public float volume;
        [Range(-3, 3)]
        public float pitch = 1;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}