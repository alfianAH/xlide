﻿using UnityEngine;

namespace Audio
{
    public enum ListSound
    {
        BackgroundMusic,
        ButtonClick,
        PreparationTime,
        WrongClick
    }
    
    [System.Serializable]
    public class Sound
    {
        public ListSound listSound;
        
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