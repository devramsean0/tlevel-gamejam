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

    public float healthRegen;

    public PlayerUpgrades()
    {
        damageMult = 1;
        playerSpeedMult = 1;
        speedMult = 1;
        sizeMult = 1;
        poisonMult = 0;
        ballCloneChance = 0;
        ballCloneAmount = 0;
        healthRegen = 0;
    }

    public PlayerUpgrades(float damageMult, float playerSpeedMult, float speedMult, float sizeMult, float poisonMult, int ballCloneChance, int ballCloneAmount, float healthRegen)
    {
        this.damageMult = damageMult;
        this.playerSpeedMult = playerSpeedMult;
        this.speedMult = speedMult;
        this.sizeMult = sizeMult;
        this.poisonMult = poisonMult;
        this.ballCloneChance = ballCloneChance;
        this.ballCloneAmount = ballCloneAmount;
        this.healthRegen = healthRegen;
    }
}