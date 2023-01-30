using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using GalaxyShooter.Core;
using UnityEngine.SceneManagement;

namespace GalaxyShooter.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private Image _livesImage;
        [SerializeField] private TMP_Text _ScoreText;

        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _gamaMenuPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _settingsPanel;

        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;
        
        [SerializeField] private Button _settingsButton;
        
        [SerializeField] private List<Sprite> _livesSprites;
        #endregion

        #region Unity Methods

        private void Start()
        {
            _livesImage.sprite = _livesSprites[_playerSO.Lives];
            _ScoreText.text = _playerSO.Score.ToString();
        }

        private void OnEnable()
        {
            _playerSO.OnLivesChange += UpdateLives;
            _playerSO.OnScoreChange += UpdateScore;

            GameManager.OnGameStateChanged += OnGameStateChanged;
            
            _musicSlider.onValueChanged.AddListener(GameManager.Instance.audioManager.SetMusicVolume);
            _sfxSlider.onValueChanged.AddListener(GameManager.Instance.audioManager.SetSfxVolume);
            
            _settingsButton.onClick.AddListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.GamePause));
        }

        private void OnDisable()
        {
            _playerSO.OnLivesChange -= UpdateLives;
            _playerSO.OnScoreChange -= UpdateScore;
            
            GameManager.OnGameStateChanged -= OnGameStateChanged;
            
            _musicSlider.onValueChanged.RemoveListener(GameManager.Instance.audioManager.SetMusicVolume);
            _sfxSlider.onValueChanged.RemoveListener(GameManager.Instance.audioManager.SetSfxVolume);
            
            _settingsButton.onClick.RemoveListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.GamePause));
        }

        #endregion

        #region UI Methods

        private void UpdateLives(int lives)
        {
            _livesImage.sprite = _livesSprites[_playerSO.Lives];
        }

        private void UpdateScore(int score)
        {
            _ScoreText.text = score.ToString();
        }

        private void OnGameStateChanged(GameManager.GameState gameState)
        {
            _mainMenuPanel.SetActive(gameState == GameManager.GameState.MainMenu);
            _gamaMenuPanel.SetActive(gameState is GameManager.GameState.GameStart or GameManager.GameState.Continue);
            _gameOverPanel.SetActive(gameState == GameManager.GameState.GameOver);
            _settingsPanel.SetActive(gameState == GameManager.GameState.GamePause);
        }

        #endregion
    }
}