using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    public bool shouldLookAtPlayer;
    GameObject playerCore;
    Rigidbody rb;
    void Start()
    {
        playerCore = GameObject.FindWithTag("Core");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldLookAtPlayer)
        {
            LookAtPlayer();
        }
    }

    void LookAtPlayer()
    {
        float angleToPlayer = Vector3.SignedAngle((playerCore.transform.position - transform.position).normalized, Vector3.forward, Vector3.down);
        if (angleToPlayer < 0)
        {
            angleToPlayer += 360;
        }
        float YVel = angleToPlayer - transform.rotation.eulerAngles.y;
        if (YVel > 0 && 360 - YVel < YVel)
        {
            YVel = (360 - YVel) * -1;
        }
        else if (YVel < 0 && 360 + YVel < YVel * -1)
        {
            YVel = 360 + YVel;
        }


        rb.angularVelocity = new Vector3(0f, YVel, 0f);
    }
}
