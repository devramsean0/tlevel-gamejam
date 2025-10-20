using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private UIDocument gameOverMenu;

    private void Awake()
    {
        UIShared.setVisible(gameOverMenu);
        gameOverMenu.rootVisualElement.Q<Button>("play").clicked += switchToGame;
        gameOverMenu.rootVisualElement.Q<Button>("exit").clicked += UIShared.gameQuit;
    }

    private void switchToGame()
    {
        Debug.Log("Switching to Main Scene");
        SceneManager.LoadScene("GameplayScene");
    }
}