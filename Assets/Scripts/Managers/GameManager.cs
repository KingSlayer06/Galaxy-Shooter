using System;
using System.Diagnostics;
using GalaxyShooter.Core;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GalaxyShooter.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        public static GameManager Instance;

        public enum GameState { Start, End }
        public static event Action<GameState> OnGameStateChanged;

        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private PlayerSO _playerSO;

        [SerializeField] public AudioManager audioManager;

        private GameState _gameState;

        private GameObject _player;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateGameState(GameState.Start);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                OnGameRestart();
            if (Input.GetKeyDown(KeyCode.Q))
                OnGameQuit();
        }

        public void UpdateGameState(GameState gameState)
        {
            _gameState = gameState;

            switch (gameState)
            {
                case GameState.Start:
                    Debug.Log("Game Start");
                    OnGameStart();
                    break;
                case GameState.End:
                    Debug.Log("Game End");
                    break;
                default:
                    return;
            }
            
            OnGameStateChanged?.Invoke(gameState);
        }

        #endregion

        #region GameState Callbacks

        private void OnGameStart()
        {
            if (_player == null)
                _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
            
            //_audioManager.PlayBackgroundMusic();
        }

        private void OnGameRestart()
        {
            UpdateGameState(GameState.Start);
        }

        private void OnGameQuit()
        {
            UpdateGameState(GameState.End);
            //_audioManager.StopBackgroundMusic();
        }

        #endregion
    }
}
