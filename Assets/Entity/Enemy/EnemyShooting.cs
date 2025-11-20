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
        GameObject newBall;
        if (GetComponent<TurretMain>())
        {
            newBall = Instantiate(ballPrefab, transform.position + Quaternion.Euler(0, angleFromEnemy, 0) * transform.forward * 3f, transform.rotation);
        }
        else
        {
            newBall = Instantiate(ballPrefab, transform.position + Quaternion.Euler(0, angleFromEnemy, 0) * transform.forward * 2f, transform.rotation);
        }
        newBall.GetComponent<Rigidbody>().linearVelocity = 1000f * Time.fixedDeltaTime * transform.forward;
        if (GetComponent<TurretMain>())
        {
            for (int i = 0; i < GetComponent<TurretMain>().turretsBalls.Count; i++)
            {
                if (GetComponent<TurretMain>().turretsBalls[i] == null)
                {
                    GetComponent<TurretMain>().turretsBalls.RemoveAt(i);
                    i -= 1;
                }
                else
                {
                    Physics.IgnoreCollision(GetComponent<TurretMain>().turretsBalls[i].GetComponent<Collider>(), newBall.GetComponent<Collider>());
                }
            }
            GetComponent<TurretMain>().turretsBalls.Add(newBall);
            newBall.GetComponent<BallMain>().ballStats = new BallClass(GetComponent<TurretMain>().turretInfo);
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newBall.GetComponent<Collider>());
        }
        else if (GetComponent<EnemyStats>())
        {
            newBall.GetComponent<BallMain>().ballStats = new BallClass(GetComponent<EnemyStats>().enemyInfo);
        }
    }
}
