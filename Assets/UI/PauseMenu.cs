using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenu;
    [SerializeField] private UIDocument settingsMenu;
    [SerializeField] private UIDocument pauseMenu;

    private void Awake()
    {
        UIShared.setInvisible(pauseMenu);
        pauseMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;
        pauseMenu.rootVisualElement.Q<Button>("exit-main").clicked += doQuitToMain;
        pauseMenu.rootVisualElement.Q<Button>("settings").clicked += switchToSettings;
    }

    private void doQuitToMain()
    {
        UIShared.setInvisible(pauseMenu);
        UIShared.setVisible(mainMenu);
    }

    private void switchToSettings()
    {
        UIShared.setInvisible(mainMenu);
        UIShared.setVisible(settingsMenu);
    }

    public void switchToPause()
    {
        SceneManager.LoadScene("MenuScene");
        UIShared.setInvisible(mainMenu);
        UIShared.setVisible(pauseMenu);
    }
}