using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenu;

    private void Awake()
    {
        UIShared.setVisible(mainMenu);
        mainMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;

    }
}