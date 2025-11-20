using System;

[Serializable]
public class BallClass
{
    public float damage;
    public float speed;
    public float size;
    public float poisonDamage;

    public int ballDurability = -1;

    public BallClass(float damage, float speed, float size, float poisonMult)
    {
        this.damage = damage;
        this.speed = speed;
        this.size = size;
        poisonDamage = damage * poisonMult;
    }

    public BallClass(EnemyClass enemyStats)
    {
        damage = enemyStats.damageDealt;
        speed = 1;
        size = 0.5f;
        poisonDamage = 0;
        ballDurability = -1;
    }

    public BallClass(TurretClass enemyStats)
    {
        damage = enemyStats.damageDealt * 0.25f;
        speed = 1;
        size = 0.2f;
        poisonDamage = 0;
        ballDurability = 1;
    }
}