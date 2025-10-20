using System;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.UI.Button;

[Serializable]
[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades", order = 1)]
public class UpgradeClass : ScriptableObject
{
    public string upgradeName;
    public string upgradeDesc;
    public UpgradeRarity upgradeRarity;
}