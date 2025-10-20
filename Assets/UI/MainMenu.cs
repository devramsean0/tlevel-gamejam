using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    /*[SerializeField] private UIDocument mainMenu;
    [SerializeField] private UIDocument settingsMenu;*/

    /*private void Awake()
    {
        UIShared.setVisible(mainMenu);
        mainMenu.rootVisualElement.Q<Button>("play").clicked += switchToGame;
        mainMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;
        mainMenu.rootVisualElement.Q<Button>("settings").clicked += switchToSettings;
    }*/

    public void switchToGame()
    {
        Debug.Log("Switching to Main Scene");
        SceneManager.LoadScene("GameplayScene");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    /*private void switchToSettings()
    {
        UIShared.setInvisible(mainMenu);
        UIShared.setVisible(settingsMenu);
    }*/
}