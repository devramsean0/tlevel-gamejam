using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TurretMain : EnemyStats
{
    public GameObject ballPrefab;
    public TurretClass turretInfo;

    public List<GameObject> turretsBalls;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (turretInfo.CountdownToShot())
        {
            ShootBalls();
        }
    }

    void FixedUpdate()
    {
        rb.angularVelocity = new Vector3(0, turretInfo.spinSpeed * Time.fixedDeltaTime * 10f, 0);
    }
    
    void ShootBalls()
    {
        for (int i = 0; i < turretInfo.ballsAtOnce; i++)
        {
            gameObject.GetComponent<EnemyShooting>().Shoot((360 / turretInfo.ballsAtOnce) * (i - 1));
            turretInfo.ballsLeft -= 1;
            if (turretInfo.ballsLeft <= 0)
            {
                waveHandler.GetComponent<WaveScript>().currentEnemiesAlive.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }

    
}
