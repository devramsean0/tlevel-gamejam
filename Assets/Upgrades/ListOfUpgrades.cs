using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListOfUpgrades : MonoBehaviour
{
    public List<UpgradeClass> upgrades;

    void Awake()
    {
        DisplayPowerUpOption(0);
        DisplayPowerUpOption(1);
        DisplayPowerUpOption(2);
                        
    }

    void DisplayPowerUpOption(int powerUpOptionIndex)
    {
        UpgradeClass upgrade = upgrades[Random.Range(0, upgrades.Count)];
        upgrades.Remove(upgrade);

        transform.GetChild(powerUpOptionIndex).GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.upgradeName;
        transform.GetChild(powerUpOptionIndex).GetChild(1).GetComponent<TextMeshProUGUI>().text = upgrade.upgradeDesc;
    }
}
