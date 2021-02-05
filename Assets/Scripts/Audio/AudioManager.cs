using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager: MonoBehaviour
    {
        public Sound[] sounds;
        
        private static AudioManager instance;

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
        /// Play audio
        /// To call method in scripts
        /// </summary>
        /// <param name="listSound"></param>
        public void Play(ListSound listSound)
        {
            GetAudioSource(listSound).Play();
        }

        /// <summary>
        /// Overload Play method
        /// To call method in Unity
        /// </summary>
        /// <param name="soundName">Name of the sound</param>
        public void Play(string soundName)
        {
            Sound s = Array.Find(sounds, sound => sound.name == soundName);
            
            if (s == null)
            {
                Debug.LogError($"Sound: {soundName} not found!");
                return;
            }
            
            s.source.Play();
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
    }
}