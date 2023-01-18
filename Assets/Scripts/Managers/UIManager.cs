using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using GalaxyShooter.Core;

namespace GalaxyShooter.Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerSO _playerSO;
        [SerializeField] private Image _livesImage;
        [SerializeField] private TMP_Text _ScoreText;
        [SerializeField] private TMP_Text _gameOverText;

        [SerializeField] private List<Sprite> _livesSprites;
        #endregion

        #region Unity Methods

        private void Start()
        {
            _livesImage.sprite = _livesSprites[_playerSO.Lives];
            _ScoreText.text = _playerSO.Score.ToString();
            _gameOverText.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _playerSO.OnLivesChange += UpdateLives;
            _playerSO.OnScoreChange += UpdateScore;
            
            GameManager.OnGameStateChanged += GameOverText;
        }

        private void OnDisable()
        {
            _playerSO.OnLivesChange -= UpdateLives;
            _playerSO.OnScoreChange -= UpdateScore;
            
            GameManager.OnGameStateChanged -= GameOverText;
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

        private void GameOverText(GameManager.GameState gameState)
        {
            _gameOverText.gameObject.SetActive(gameState == GameManager.GameState.End);
        }

        #endregion
    }
}