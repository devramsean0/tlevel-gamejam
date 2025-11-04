public class BallClass
{
    public float damage;
    public float speed;
    public float size;
    public float poisonDamage;

    public float ballDurability;

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
        size = 1;
        poisonDamage = 0;
    }
}