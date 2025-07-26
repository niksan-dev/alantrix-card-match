using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niksan.CardGame
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        [Header("Audio")]
        [SerializeField] private List<SoundSFX> audioClips = new List<SoundSFX>();
        private Dictionary<SoundType,AudioSource> sounds = new Dictionary<SoundType, AudioSource>();

        private void Awake()
        {
            instance = this;
            foreach (var audio in audioClips)
            {
                if(!sounds.ContainsKey(audio.soundType))
                    sounds.Add(audio.soundType,audio.sfx);
            }
        }

        public void PlaySound(SoundType soundType)
        {
            if(!sounds.ContainsKey(soundType))
                sounds[soundType].Play();
        }
    }
}
[Serializable]
public class SoundSFX
{
    public AudioSource sfx;
    public SoundType soundType;
}

public enum SoundType
{
    FLIP = 0,
    MATCH = 1,
    MISMATCH = 2,
}
