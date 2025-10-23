using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMain : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    public BallClass ballStats;

    public bool hasHitPaddle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        ballStats = new BallClass(1, 1, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = 1000f * ballStats.speed * Time.fixedDeltaTime * rb.linearVelocity.normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PaddleMain>() && !hasHitPaddle)
        {
            //Applying basic stats
            ballStats.damage = player.GetComponent<PlayerStats>().playerUpgrades.damageMult;
            ballStats.speed = player.GetComponent<PlayerStats>().playerUpgrades.speedMult;
            ballStats.size = player.GetComponent<PlayerStats>().playerUpgrades.sizeMult * 0.5f;
            ballStats.poisonDamage = player.GetComponent<PlayerStats>().playerUpgrades.poisonMult * ballStats.damage;

            //Applying physics and flags
            hasHitPaddle = true;
            transform.localScale = new Vector3(ballStats.size, ballStats.size, ballStats.size);
            rb.linearVelocity *= ballStats.speed;


            //Cloning balls
            for (int i = 0; i < player.GetComponent<PlayerStats>().playerUpgrades.ballCloneAmount; i++)
            {
                GameObject newClone = Instantiate(gameObject, transform.position + (collision.transform.right * 0.1f * i), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y + (15 * i), transform.rotation.z)));
            }
        }
    }
}
