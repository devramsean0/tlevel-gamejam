public class BallClass
{
    public float damage;
    public float speed;
    public float size;
    public float poisonDamage;

    public BallClass(float damage, float speed, float size, float poisonMult)
    {
        this.damage = damage;
        this.speed = speed;
        this.size = size;
        poisonDamage = damage * poisonMult;
    }
}