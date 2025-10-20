using System;
using System.Collections.Generic;

[Serializable]
public class EnemyClass
{
    public float maxHealth;
    public float currentHealth;

    public float currentPoisonDamage;

    public float currentPoisonTime;
    public float timeBetweenBalls;

    public float damageDealt;

    public EnemyClass(int maxHealth, float timeBetweenBalls, float damageDealt)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.timeBetweenBalls = timeBetweenBalls;
        this.damageDealt = damageDealt;
    }
}