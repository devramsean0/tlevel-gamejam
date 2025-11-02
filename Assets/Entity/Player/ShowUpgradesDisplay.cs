using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShowUpgradesDisplay : MonoBehaviour
{
    InputAction upgradeDisplayAction;
    bool upgradeDisplayOpen = false;
    void Start()
    {
        upgradeDisplayAction = InputSystem.actions.FindAction("UpgradesDisplay");
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeDisplayAction.WasPressedThisFrame())
        {
            if (!upgradeDisplayOpen)
            {
                SceneManager.LoadScene("UpgradesAndStatsDisplay", LoadSceneMode.Additive);
                Time.timeScale = 0f;
            }
            else
            {
                SceneManager.UnloadSceneAsync("UpgradesAndStatsDisplay");
                Time.timeScale = 1f;
            }
            upgradeDisplayOpen = !upgradeDisplayOpen;
        }
    }
}
