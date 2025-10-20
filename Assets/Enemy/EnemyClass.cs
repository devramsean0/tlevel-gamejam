using System;
using System.Collections.Generic;

[Serializable]
public class EnemyClass
{
    public int maxHealth;
    public int currentHealth;
    public float timeBetweenBalls;

    public EnemyClass(int maxHealth, float timeBetweenBalls)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.timeBetweenBalls = timeBetweenBalls;
    }
}