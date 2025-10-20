using UnityEngine;

public class AllUpgradeEffects : MonoBehaviour
{
    public GameObject player;
    public void PoisonUpgrade()
    {
        player.GetComponent<PlayerStats>().playerUpgrades.poisonMult += 0.05f;
    }
}
