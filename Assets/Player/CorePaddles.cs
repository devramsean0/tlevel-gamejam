using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CorePaddles : MonoBehaviour
{
    [SerializeField] GameObject paddlePrefab;
    public List<GameObject> paddles;
    void Start()
    {
        GameObject newPaddle = Instantiate(paddlePrefab);
        newPaddle.transform.position = transform.position + transform.forward * 2f;
        newPaddle.GetComponent<PaddleMain>().rotationOffset = transform.rotation.y;
        Physics.IgnoreCollision(GetComponent<Collider>(), newPaddle.GetComponent<Collider>());
        paddles.Add(newPaddle);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
