using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyClass enemyInfo;
    public GameObject waveHandler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInfo.currentPoisonTime > 0)
        {
            int prevPoisTime = (int)enemyInfo.currentPoisonTime;
            enemyInfo.currentPoisonTime -= Time.deltaTime;
            if (prevPoisTime > (int)enemyInfo.currentPoisonTime)
            {
                enemyInfo.currentHealth -= enemyInfo.currentPoisonDamage;
            }
        }
        else if (enemyInfo.currentPoisonDamage > 0) {
            enemyInfo.currentPoisonDamage = 0;
        }
        if (enemyInfo.currentHealth <= 0)
        {
            waveHandler.GetComponent<WaveScript>().currentEnemiesAlive.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallMain>())
        {
            enemyInfo.currentHealth -= collision.gameObject.GetComponent<BallMain>().ballStats.damage;
            if (collision.gameObject.GetComponent<BallMain>().ballStats.poisonDamage > 0)
            {
                enemyInfo.currentPoisonDamage = collision.gameObject.GetComponent<BallMain>().ballStats.poisonDamage;
                enemyInfo.currentPoisonTime = 3f;
            }
            Destroy(collision.gameObject);
        }
    }
}
