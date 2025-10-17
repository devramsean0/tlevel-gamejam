using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject ballPrefab;

    public float shootingInterval = 4f;
    float timeUntilNextShot = 4f;

    void Awake()
    {
        timeUntilNextShot = shootingInterval;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextShot -= Time.deltaTime;
        if (timeUntilNextShot <= 0)
        {
            Shoot();
            timeUntilNextShot = shootingInterval;
        }
    }

    void Shoot()
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position + transform.forward * 2, transform.rotation);
        newBall.GetComponent<Rigidbody>().linearVelocity = transform.forward * 10f;
    }
}
