using UnityEngine;
using UnityEngine.SceneManagement;

namespace GCP.Orchestration
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private string currentLevel = "Level 1";
        [SerializeField] private string nextLevel = "Level 2";

        public void RestartLevel()
        {
            SceneManager.LoadScene(currentLevel);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(nextLevel);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("_MainMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}