using TMPro;
using UnityEngine;

public class UpgradesAndStatsDisp : MonoBehaviour
{
    GameObject player;
    Transform statsSection;
    Transform upgradesSection;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statsSection = transform.GetChild(0); //UI for stats
        upgradesSection = transform.GetChild(1); //UI for upgrades
    }

    // Update is called once per frame
    void Update()
    {
        statsSection.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Damage: x{player.GetComponent<PlayerStats>().playerUpgrades.damageMult}";
        statsSection.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"Poison Damage: x{player.GetComponent<PlayerStats>().playerUpgrades.poisonMult}";
        statsSection.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Ball Speed: x{player.GetComponent<PlayerStats>().playerUpgrades.speedMult}";
        statsSection.GetChild(4).GetComponent<TextMeshProUGUI>().text = $"Ball Size: x{player.GetComponent<PlayerStats>().playerUpgrades.sizeMult}";
        statsSection.GetChild(5).GetComponent<TextMeshProUGUI>().text = $"Player Speed: x{player.transform.GetChild(1).GetChild(0).GetComponent<CoreMovement>().speed}";
        statsSection.GetChild(6).GetComponent<TextMeshProUGUI>().text = $"Clone Chance: {player.GetComponent<PlayerStats>().playerUpgrades.ballCloneChance * 100}%";
        statsSection.GetChild(7).GetComponent<TextMeshProUGUI>().text = $"Clone Amount: x{player.GetComponent<PlayerStats>().playerUpgrades.ballCloneAmount}";
    }
}
