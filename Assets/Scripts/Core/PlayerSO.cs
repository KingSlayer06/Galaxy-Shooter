using System;
using GalaxyShooter.Managers;
using UnityEngine;

namespace GalaxyShooter.Core
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerData")]
    public class PlayerSO : ScriptableObject
    {
        #region Variables
        
        [SerializeField] private int _lives;
        [SerializeField] private float _speed;
        [SerializeField] private int _score;
        [SerializeField] private Vector3 _laserSpawnOffset;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private GameObject _tripleShotLaserPrefab;
        [SerializeField] private GameObject _shieldPrefab;

        private bool _isTripleShotEnabled;

        public event Action<int> OnLivesChange;
        public event Action<int> OnScoreChange; 
        public event Action<bool> OnTripleShotEnabled;

        #endregion

        #region Properties

        public int Lives
        {
            get => _lives;
            set
            {
                _lives = value;
                OnLivesChange?.Invoke(_lives);
            }
        }
    
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChange?.Invoke(_score);
            }
        }

        public Vector3 LaserSpawnOffset
        {
            get => _laserSpawnOffset;
            set => _laserSpawnOffset = value;
        }

        public GameObject LaserPrefab => _laserPrefab;
        public GameObject TripleShotLaserLaserPrefab => _tripleShotLaserPrefab;
        public GameObject ShieldPrefab => _shieldPrefab;

        public bool TripleShotEnabled
        {
            get => _isTripleShotEnabled;
            set
            {
                _isTripleShotEnabled = value;
                OnTripleShotEnabled?.Invoke(_isTripleShotEnabled);
            }
        }

        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            _isTripleShotEnabled = false;
            _score = 0;
            _speed = 12.5f;
            _lives = 3;
        }

        #endregion
    }
}