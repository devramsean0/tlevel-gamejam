using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveScript : MonoBehaviour
{
    public int currentWaveNum;
    public GameObject enemyPrefab;
    public GameObject ballPrefab;

    public WaveClass currWaveData;

    public float timeUntilNextSpawn = 0;
    public List<GameObject> currentEnemiesAlive = new();
    public int enemiesSpawnedThisWave = 0;


    void Awake()
    {
        currentWaveNum = 0;
        NewWave();
        timeUntilNextSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;
        if (timeUntilNextSpawn <= 0 && currentEnemiesAlive.Count < currWaveData.maxEnemyAtOnce && enemiesSpawnedThisWave < currWaveData.enemyAmountThisWave)
        {
            NewEnemy();
        }

        if (enemiesSpawnedThisWave >= currWaveData.enemyAmountThisWave)
        {
            NewWave();
        }
    }

    void NewEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);
        newEnemy.GetComponent<EnemyStats>().enemyInfo = new EnemyClass(
            (int)Random.Range(1, currWaveData.maxEnemyStats.maxHealth),
            Random.Range(currWaveData.maxEnemyStats.timeBetweenBalls, 3),
            currWaveData.maxEnemyStats.damageDealt
            );
        newEnemy.GetComponent<EnemyStats>().waveHandler = gameObject;
        currentEnemiesAlive.Add(newEnemy);
        timeUntilNextSpawn = currWaveData.timeBetweenEnemySpawn;
        enemiesSpawnedThisWave += 1;
        Debug.Log($"new enemy spawned at {newEnemy.transform.position}  ({enemiesSpawnedThisWave}/{currWaveData.enemyAmountThisWave})");
    }

    void NewWave()
    {
        if (currentWaveNum > 0)
        {
            SceneManager.LoadScene("PowerUpOptions", LoadSceneMode.Additive);
            Time.timeScale = 0;
        }

        currentWaveNum += 1;
        timeUntilNextSpawn = 0;
        enemiesSpawnedThisWave = 0;
        currWaveData = new WaveClass(currentWaveNum);
    }
}
