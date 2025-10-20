using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllUpgradeEffects : MonoBehaviour
{
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void FindUpgrade()
    {
        Debug.Log(transform.GetChild(0));
        string upgradeName = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        if (upgradeName == "Damage")
        {
            DamageUpgrade();
        }
        if (upgradeName == "Poison")
        {
            PoisonUpgrade();
        }
        if (upgradeName == "Size")
        {
            SizeUpgrade();
        }
        if (upgradeName == "Speed")
        {
            SpeedUpgrade();
        }
        else if (upgradeName == "Player Speed")
        {
            PlayerSpeedUpgrade();
        }
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PowerUpOptions");
    }

    void DamageUpgrade()
    {
        player.GetComponent<PlayerStats>().playerUpgrades.damageMult *= 1.05f;
    }

    void SpeedUpgrade()
    {
        player.GetComponent<PlayerStats>().playerUpgrades.speedMult *= 1.05f;
    }

    void SizeUpgrade()
    {
        player.GetComponent<PlayerStats>().playerUpgrades.sizeMult *= 1.05f;
    }
    void PoisonUpgrade()
    {
        player.GetComponent<PlayerStats>().playerUpgrades.poisonMult *= 1.05f;
    }

    void PlayerSpeedUpgrade()
    {
        player.transform.GetChild(1).GetChild(0).GetComponent<CoreMovement>().speed *= 1.1f;
    }
}
