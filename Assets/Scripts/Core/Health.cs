using System;
using GalaxyShooter.Managers;
using UnityEngine;

namespace GalaxyShooter.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private GameObject _fireEffect;
        [SerializeField] private GameObject _explosionPrefab;

        [SerializeField] private int _maxLives;

        private void Start()
        {
            _fireEffect.SetActive(false);
            GameManager.OnGameStateChanged += ResetHealth;
        }

        private void ResetHealth(GameManager.GameState gameState)
        {
            if (gameState == GameManager.GameState.Start)
                _playerSO.Lives = _maxLives;
        }

        public void TakeDamage()
        {
            if (_playerSO.Lives > 0)
            {
                _playerSO.Lives -= 1;
                _fireEffect.SetActive(true);
            }

            if (_playerSO.Lives == 0)
            {
                GameManager.Instance.UpdateGameState(GameManager.GameState.End);
                GameManager.Instance.audioManager.PlaySound("explosion");
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
