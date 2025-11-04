using System;
using UnityEngine;

[Serializable]
public class TurretClass : EnemyClass
{
    public int ballCapacity;
    public int ballsLeft;

    public int ballsAtOnce; //Balls fired per "shot"

    public float spinSpeed;

    public TurretClass(int maxHealth, int ballCapacity, float timeBetweenBalls, float damageDealt, int ballsAtOnce, float spinSpeed)
    {
        enemyType = EnemyType.single;
        this.maxHealth = maxHealth;
        this.timeBetweenBalls = timeBetweenBalls;
        this.damageDealt = damageDealt;
        this.ballsAtOnce = ballsAtOnce;
        this.ballCapacity = ballCapacity;
        ballsLeft = ballCapacity;
        this.spinSpeed = spinSpeed;
    }

}
