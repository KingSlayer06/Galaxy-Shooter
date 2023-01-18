using System;
using GalaxyShooter.Audio;
using UnityEngine;

namespace GalaxyShooter.Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioSource _musicSFX;
        [SerializeField] private AudioSource _SoundSFX;
        [SerializeField] private SoundsSO _soundsSO;

        #endregion

        #region UnityMethods

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += PlayBackgroundMusic;
        }

        #endregion

        #region Audio Callbacks

        public void PlayBackgroundMusic(GameManager.GameState gameState)
        {
            if (gameState == GameManager.GameState.Start)
            {
                _musicSFX.clip = _soundsSO.BackgroundMusic;
                _musicSFX.loop = true;
                _musicSFX.Play();
            }
            else
            {
                _musicSFX.Stop();
            }
        }

        public void PlaySound(string soundName)
        {
            switch (soundName)
            {
                case "laser": _SoundSFX.PlayOneShot(_soundsSO.Sounds[0]);
                    break;
                case "explosion": _SoundSFX.PlayOneShot(_soundsSO.Sounds[1]);
                    break;
                case "powerUp": _SoundSFX.PlayOneShot(_soundsSO.Sounds[2]);
                    break;
                default:
                    return;
            }
        }

        #endregion
    }
}
