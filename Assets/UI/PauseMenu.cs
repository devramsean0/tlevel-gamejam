using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    public void switchToGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1.0f;
    }

    public void doQuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void switchToPause()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
}