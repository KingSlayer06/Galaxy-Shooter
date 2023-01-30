using GalaxyShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyShooter.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameBtn;
        [SerializeField] private Button _endGameBtn;

        private void Start()
        {
            _startGameBtn.onClick.AddListener(StartGame);
            _endGameBtn.onClick.AddListener(QuitGame);
        }

        private void OnDestroy()
        {
            _startGameBtn.onClick.RemoveListener(StartGame);
            _endGameBtn.onClick.RemoveListener(QuitGame);
        }

        private void StartGame()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.GameStart);
        }

        private void QuitGame()
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Quit);
        }
    }
}
