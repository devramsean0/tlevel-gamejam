using UnityEngine;

public class PaddleMain : MonoBehaviour
{
    public float rotationOffset;
    public Vector3 intendedLocation;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = (intendedLocation - transform.position) * 10;
        rb.angularVelocity = new Vector3(0, rotationOffset, 0) - new Vector3(0, transform.rotation.y, 0) ;
        Debug.Log(rb.angularVelocity);
    }
    void Update()
    {
        
    }
}
