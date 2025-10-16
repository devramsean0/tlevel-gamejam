using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenu;
    [SerializeField] private UIDocument pauseMenu;

    private void Awake()
    {
        UIShared.setInvisible(pauseMenu);
        pauseMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;
        pauseMenu.rootVisualElement.Q<Button>("exit-main").clicked += doQuitToMain;
    }

    private void doQuitToMain()
    {
        UIShared.setInvisible(pauseMenu);
        UIShared.setVisible(mainMenu);
    }
}