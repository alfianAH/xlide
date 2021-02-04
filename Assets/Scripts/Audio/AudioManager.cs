using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager: MonoBehaviour
    {
        public Sound[] sounds;
        
        private static AudioManager instance;
        private const string BackgroundMusic = "BackgroundMusic";

        private void Awake()
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
            Play(BackgroundMusic);
        }

        /// <summary>
        /// Play audio
        /// </summary>
        /// <param name="audioName">Name of the file</param>
        public void Play(string audioName)
        {
            Sound s = Array.Find(sounds, sound => sound.name == audioName);
            if (s == null)
            {
                Debug.LogError($"Sound: {audioName} not found!");
                return;
            }
            s.source.Play();
        }
    }
}