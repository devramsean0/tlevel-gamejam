using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveScript : MonoBehaviour
{
    public int currentWaveNum;
    public List<GameObject> enemyPrefabs = new();
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
        timeUntilNextSpawn -= Time.deltaTime * Time.timeScale;
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
        int enemyChosen = Random.Range(0, (currentWaveNum / 4) + 1) % enemyPrefabs.Count;
        GameObject newEnemy = Instantiate(enemyPrefabs[enemyChosen], new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);

        //Enemy Stats
        if (newEnemy.GetComponent<TurretMain>())
        {
            newEnemy.GetComponent<TurretMain>().turretInfo = new TurretClass(
                99999,
                currentWaveNum * 40,
                0.3f,
                currWaveData.maxEnemyStats.damageDealt,
                Random.Range(1, 5),
                30f
            );
        }
        else if (newEnemy.GetComponent<TripletPaddles>())
        {
            for (int i = 0; i < newEnemy.transform.childCount; i++)
            {
                newEnemy.transform.GetChild(i).GetComponent<EnemyStats>().enemyInfo = new EnemyClass(
                    EnemyType.connected,
                    (int)Random.Range(1, currWaveData.maxEnemyStats.maxHealth),
                    Random.Range(currWaveData.maxEnemyStats.timeBetweenBalls, 3),
                    currWaveData.maxEnemyStats.damageDealt
                    );
            }
        }
        else
        {
            newEnemy.GetComponent<EnemyStats>().enemyInfo = new EnemyClass(
                EnemyType.single,
                (int)Random.Range(1, currWaveData.maxEnemyStats.maxHealth),
                Random.Range(currWaveData.maxEnemyStats.timeBetweenBalls, 3),
                currWaveData.maxEnemyStats.damageDealt
                );
        }

        //Assigning wave handler
        if (newEnemy.GetComponent<TripletPaddles>())
        {
            newEnemy.GetComponent<TripletPaddles>().waveHandler = gameObject;
        }
        else if (newEnemy.GetComponent<TurretMain>())
        {
            newEnemy.GetComponent<TurretMain>().waveHandler = gameObject;
        }
        else
        {
            newEnemy.GetComponent<EnemyStats>().waveHandler = gameObject;
        }
        
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
