using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject ballPrefab;

    void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<EnemyStats>().enemyInfo.CountdownToShot())
        {
            Shoot();
        }
    }

    public void Shoot(float angleFromEnemy = 0f)
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position + Quaternion.Euler(0, angleFromEnemy, 0) * transform.forward * 2f, transform.rotation);
        newBall.GetComponent<Rigidbody>().linearVelocity = 1000f * Time.fixedDeltaTime * transform.forward;
        newBall.GetComponent<BallMain>().ballStats = new BallClass(GetComponent<EnemyStats>().enemyInfo);
    }
}
