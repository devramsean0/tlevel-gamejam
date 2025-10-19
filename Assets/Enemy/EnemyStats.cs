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
            enemyInfo.currentHealth -= 1;
            Destroy(collision.gameObject);
        }
    }
}
