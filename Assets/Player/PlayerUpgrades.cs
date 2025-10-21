using System;

[Serializable]
public class PlayerUpgrades
{
    public float damageMult;
    public float speedMult;
    public float sizeMult;
    public float poisonMult;
    public int ballCloneAmount;

    public PlayerUpgrades(float damageMult, float speedMult, float sizeMult, float poisonMult, int ballCloneAmount)
    {
        this.damageMult = damageMult;
        this.speedMult = speedMult;
        this.sizeMult = sizeMult;
        this.poisonMult = poisonMult;
        this.ballCloneAmount = ballCloneAmount;
    }
}