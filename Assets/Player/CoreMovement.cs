using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CoreMovement : MonoBehaviour
{
    InputAction moveAction;
    InputAction turnAction;
    Rigidbody rb;

    public float speed = 10f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        turnAction = InputSystem.actions.FindAction("Turn");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Turn();
    }

    void Movement()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector3(movement.x, 0, movement.y) * speed;
    }

    void Turn()
    {
        float turnValue = turnAction.ReadValue<float>();
        rb.angularVelocity = new Vector3(0, turnValue * speed, 0);
    }
}
