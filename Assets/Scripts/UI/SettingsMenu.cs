using GalaxyShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GalaxyShooter.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _mainMenuButton;
        
        private void Start()
        {
            _backButton.onClick.AddListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.Continue));
            _mainMenuButton.onClick.AddListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenu));
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.Continue));
            _mainMenuButton.onClick.RemoveListener(
                () => GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenu));
        }
    }
}
