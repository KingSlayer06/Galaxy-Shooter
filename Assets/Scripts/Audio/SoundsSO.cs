using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GalaxyShooter.Audio
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SoundData")]
    public class SoundsSO : ScriptableObject
    {
        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] private List<AudioClip> _sounds;
        
        public AudioClip BackgroundMusic
        {
            get => _backgroundMusic;
            set => _backgroundMusic = value;
        }

        public List<AudioClip> Sounds
        {
            get => _sounds;
            set => _sounds = value;
        }
    }
}
