using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
}
