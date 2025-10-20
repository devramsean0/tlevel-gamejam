using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    /*[SerializeField] private UIDocument mainMenu;
    [SerializeField] private UIDocument settingsMenu;
    [SerializeField] private UIDocument pauseMenu;*/

    /*private void Awake()
    {
        UIShared.setInvisible(pauseMenu);
        pauseMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;
        pauseMenu.rootVisualElement.Q<Button>("exit-main").clicked += doQuitToMain;
        pauseMenu.rootVisualElement.Q<Button>("settings").clicked += switchToSettings;
    }*/

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