using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyClass
{
    public EnemyType enemyType;
    public float maxHealth;
    public float currentHealth;

    public float currentPoisonDamage;

    public float currentPoisonTime;
    public float timeBetweenBalls;

    public float timeUntilNextBalls;

    public float damageDealt;

    public EnemyClass()
    {
        
    }

    public EnemyClass(EnemyType enemyType, int maxHealth, float timeBetweenBalls, float damageDealt)
    {
        this.enemyType = enemyType;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.timeBetweenBalls = timeBetweenBalls;
        this.damageDealt = damageDealt;
    }

    public bool CountdownToShot()
    {
        timeUntilNextBalls -= Time.deltaTime;
        if (timeUntilNextBalls <= 0)
        {
            timeUntilNextBalls = timeBetweenBalls;
            return true;
        }
        return false;
    }
}