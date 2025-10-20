using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListOfUpgrades : MonoBehaviour
{
    public List<UpgradeClass> upgrades;
    public List<UpgradeClass> commonUpgrades = new();
    public List<UpgradeClass> rareUpgrades = new();
    public List<UpgradeClass> legendaryUpgrades = new();
    public List<UpgradeClass> ballerUpgrades = new();

    void Awake()
    {
        foreach (UpgradeClass upgrade in upgrades)
        {
            switch (upgrade.upgradeRarity)
            {
                case UpgradeRarity.common:
                    commonUpgrades.Add(upgrade);
                    break;

                case UpgradeRarity.rare:
                    rareUpgrades.Add(upgrade);
                    break;

                case UpgradeRarity.legendary:
                    legendaryUpgrades.Add(upgrade);
                    break;

                case UpgradeRarity.baller:
                    ballerUpgrades.Add(upgrade);
                    break;

                default:
                    break;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            int rarityLevel = Random.Range(1, 101);
            Debug.Log(rarityLevel);
            if (rarityLevel > 99 && ballerUpgrades.Count > 0) {
                DisplayPowerUpOption(i, ballerUpgrades);
            }
            else if (rarityLevel > 90 && legendaryUpgrades.Count > 0) {
                DisplayPowerUpOption(i, legendaryUpgrades);
            }
            else if (rarityLevel > 75 && rareUpgrades.Count > 0) {
                DisplayPowerUpOption(i, rareUpgrades);
            }
            else {
                DisplayPowerUpOption(i, commonUpgrades);
            }
        }               
    }

    void DisplayPowerUpOption(int powerUpOptionIndex, List<UpgradeClass> upgradesTable)
    {
        UpgradeClass upgrade = upgradesTable[Random.Range(0, upgradesTable.Count)];
        upgradesTable.Remove(upgrade);

        transform.GetChild(powerUpOptionIndex).GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.upgradeName;
        transform.GetChild(powerUpOptionIndex).GetChild(1).GetComponent<TextMeshProUGUI>().text = upgrade.upgradeDesc;
    }
}
