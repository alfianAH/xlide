using System;
using UnityConfig;
using UnityEngine;

namespace Audio
{
    public class AudioManager: MonoBehaviour
    {
        [ArrayElementTitle("listSound")]
        public Sound[] sounds;
        
        private static AudioManager instance;

        #region MONOBEHAVIOUR_METHODS
        
        private void Awake()
        {
            SetInstance();
            
            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;

                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }

        private void Start()
        {
            Play(ListSound.BackgroundMusic);
        }
        
        #endregion

        #region PUBLIC_METHODS
        
        /// <summary>
        /// Play audio
        /// To call method in scripts
        /// </summary>
        /// <param name="listSound"></param>
        public void Play(ListSound listSound)
        {
            GetAudioSource(listSound).Play();
        }
        
        #endregion

        #region PRIVATE_METHODS
        
        /// <summary>
        /// Set instance and don't destroy on load
        /// </summary>
        private void SetInstance()
        {
            if (instance ==  null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
        }
        
        /// <summary>
        /// Get audio source for enum
        /// </summary>
        /// <param name="listSound"></param>
        /// <returns></returns>
        private AudioSource GetAudioSource(ListSound listSound)
        {
            Sound s = Array.Find(sounds, sound => sound.listSound == listSound);
            
            if (s == null)
            {
                Debug.LogError($"Sound: {listSound} not found!");
                return null;
            }
            
            return s.source;
        }
        
        #endregion
    }
}