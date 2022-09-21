using _PROJECT.Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _PROJECT.Scripts.MainMenu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField]
        private Button startGameButton;
        [SerializeField]
        private Button quiteGameButton;
    
        private void Start()
        {
            startGameButton.onClick.AddListener(StartGame);
            quiteGameButton.onClick.AddListener(QuiteGame);
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(StartGame);
            quiteGameButton.onClick.RemoveListener(QuiteGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(Keys.SceneIndex.PLAY_GROUND);
        }

        private void QuiteGame()
        {
            Application.Quit();
        }
    
    }
}
