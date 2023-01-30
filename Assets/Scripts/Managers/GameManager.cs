using System;
using System.Diagnostics;
using GalaxyShooter.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace GalaxyShooter.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        public static GameManager Instance;

        public enum GameState { MainMenu ,GameStart, GamePause, Continue, GameOver, Retry, Quit }
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
            UpdateGameState(GameState.MainMenu);
        }

        public void UpdateGameState(GameState gameState)
        {
            _gameState = gameState;

            switch (gameState)
            {
                case GameState.MainMenu:
                    Debug.Log("Main Menu");
                    OnGameMenu();
                    break;
                case GameState.GameStart:
                    Debug.Log("Game Start");
                    OnGameStart();
                    break;
                case GameState.GamePause:
                    Debug.Log("Game Paused");
                    OnGamePause();
                    break;
                case GameState.Continue:
                    Debug.Log("Game Continue");
                    OnGameContinue();
                    break;
                case GameState.GameOver:
                    Debug.Log("Game Over");
                    OnGameOver();
                    break;
                case GameState.Retry:
                    Debug.Log("Game Retry");
                    OnGameRetry();
                    break;
                case GameState.Quit:
                    Debug.Log("Game Quit");
                    OnGameQuit();
                    break;
                default:
                    return;
            }
            
            OnGameStateChanged?.Invoke(gameState);
        }

        #endregion

        #region GameState Callbacks

        private void OnGameMenu()
        {
            
        }

        private void OnGameStart()
        {
            Time.timeScale = 1;
            if (_player == null)
                _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        }

        private void OnGamePause()
        {
            Time.timeScale = 0;
        }

        private void OnGameContinue()
        {
            Time.timeScale = 1;
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
        }

        private void OnGameRetry()
        {
            Time.timeScale = 1;
            UpdateGameState(GameState.GameStart);
        }

        private void OnGameQuit()
        {
            Application.Quit();
        }

        #endregion
    }
}
