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
        ballStats = new BallClass(1, 1, 0.3f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PaddleMain>() && !hasHitPaddle)
        {
            ballStats.damage = player.GetComponent<PlayerStats>().playerUpgrades.damageMult;
            ballStats.speed = player.GetComponent<PlayerStats>().playerUpgrades.speedMult;
            ballStats.size = player.GetComponent<PlayerStats>().playerUpgrades.sizeMult * 0.3f;
            ballStats.poisonDamage = player.GetComponent<PlayerStats>().playerUpgrades.poisonMult * ballStats.damage;

            hasHitPaddle = true;
            transform.localScale = new Vector3(ballStats.size, ballStats.size, ballStats.size);
            rb.linearVelocity *= ballStats.speed;
        }
    }
}
