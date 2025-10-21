using System;

[Serializable]
public class PlayerUpgrades
{
    public float damageMult;
    public float speedMult;
    public float playerSpeedMult;
    public float sizeMult;
    public float poisonMult;
    public float ballCloneChance;
    public int ballCloneAmount;

    public PlayerUpgrades(float damageMult, float playerSpeedMult, float speedMult, float sizeMult, float poisonMult, int ballCloneChance, int ballCloneAmount)
    {
        this.damageMult = damageMult;
        this.playerSpeedMult = playerSpeedMult;
        this.speedMult = speedMult;
        this.sizeMult = sizeMult;
        this.poisonMult = poisonMult;
        this.ballCloneChance = ballCloneChance;
        this.ballCloneAmount = ballCloneAmount;
    }
}