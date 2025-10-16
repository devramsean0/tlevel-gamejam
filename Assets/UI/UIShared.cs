using UnityEngine;
using UnityEngine.UIElements;

public class UIShared
{
    public static void gameQuit()
    {
        Debug.Log("Application Quitting");
        Application.Quit();
    }

    public static void setInvisible(UIDocument document)
    {
        Debug.Log("Hiding UI Document");
        document.rootVisualElement.style.display = DisplayStyle.None;
    }
    public static void setVisible(UIDocument document)
    {
        Debug.Log("Showing UI Document");
        document.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
