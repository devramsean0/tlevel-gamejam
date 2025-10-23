using UnityEngine;

[RequireComponent(typeof(EnemyShooting))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyStats))]
public class IndividualTriplet : MonoBehaviour
{
    public bool alive;
    public float timeUntilRespawn;

    Rigidbody rb;
    void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            timeUntilRespawn -= Time.deltaTime;
            rb.linearVelocity = new Vector3(0,0,0);
        }
        if (!alive && timeUntilRespawn <= 0f)
        {
            TripletAlive(true);
        }
    }

    public void TripletAlive(bool isAlive)
    {
        if (alive != isAlive) //stops the function running unneccesarily
        {
            alive = isAlive;
            GetComponent<Renderer>().enabled = isAlive;
            GetComponent<Collider>().enabled = isAlive;
            GetComponent<EnemyShooting>().enabled = isAlive;
            if (isAlive)
            {
                GetComponent<EnemyStats>().enemyInfo.currentHealth = GetComponent<EnemyStats>().enemyInfo.maxHealth;
            }
            else
            {
                timeUntilRespawn = 5f;
            }
        }
    }
}
