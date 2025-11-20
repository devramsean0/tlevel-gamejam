using System.Collections.Generic;
using UnityEngine;

public class WaveClass
{
    public int enemyAmountThisWave;
    public float timeBetweenEnemySpawn;
    public int maxEnemyAtOnce;

    public EnemyClass maxEnemyStats;

    public WaveClass(int waveNum)
    {
        maxEnemyStats = new EnemyClass(EnemyType.connected, 1 + ((waveNum ^ 2) / 10), 8f - ((waveNum ^ 2) / 10), 1 + (waveNum ^ 2)/2);
        maxEnemyAtOnce = 5 + waveNum;
        enemyAmountThisWave = 10 + waveNum;
        timeBetweenEnemySpawn = 3f - (waveNum / 10);
        if (timeBetweenEnemySpawn < 0.1f)
        {
            timeBetweenEnemySpawn = 0.1f;
        }
    }
}