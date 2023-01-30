using GalaxyShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyShooter.UI
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _retryBtn;
        [SerializeField] private Button _mainMenuBtn;

        private void Start()
        {
            _retryBtn.onClick.AddListener(Retry);
            _mainMenuBtn.onClick.AddListener(MainMenu);
        }

        private void OnDestroy()
        {
            _retryBtn.onClick.RemoveListener(Retry);
            _mainMenuBtn.onClick.RemoveListener(MainMenu);
        }

        private void Retry()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GameStart);
        }

        private void MainMenu()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenu);
        }
    }
}
