using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CoreMovement : MonoBehaviour
{
    InputAction moveAction;
    InputAction turnAction;
    Rigidbody rb;

    Vector2 movement;
    float turnValue;

    public float speed = 8f;
    void Start()
    {
        Time.timeScale = 1f;
        moveAction = InputSystem.actions.FindAction("Move");
        turnAction = InputSystem.actions.FindAction("Turn");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        turnValue = turnAction.ReadValue<float>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * Time.fixedDeltaTime * new Vector3(movement.x, 0, movement.y);
        rb.angularVelocity = new Vector3(0, turnValue * speed, 0) * Time.fixedDeltaTime;
    }
}
