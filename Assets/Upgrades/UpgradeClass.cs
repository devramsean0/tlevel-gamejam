using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades", order = 1)]
public class UpgradeClass : ScriptableObject
{
    public string upgradeName;
    public string upgradeDesc;
    public UnityEvent upgradeEffect;
}