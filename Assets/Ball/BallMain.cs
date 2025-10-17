using UnityEngine;

public class BallMain : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = Vector3.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
        rb.linearVelocity = direction * rb.linearVelocity.magnitude;
    }
}
