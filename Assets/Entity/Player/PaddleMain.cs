using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PaddleMain : MonoBehaviour
{
    public GameObject playerCore;
    public float rotationOffset;
    public float extraRotationOffset; //For multiple paddles, so that theyre as far apart as possible
    public Vector3 intendedLocation;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCore = GameObject.FindWithTag("Core");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = 1000 * Time.fixedDeltaTime * (intendedLocation - transform.position);
        
        float YVel = rotationOffset - transform.rotation.eulerAngles.y;
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
    void Update()
    {
        intendedLocation = playerCore.transform.position + Quaternion.Euler(0, extraRotationOffset, 0) * playerCore.transform.forward * 2f;
        rotationOffset = playerCore.transform.rotation.eulerAngles.y + extraRotationOffset;
    }
}
