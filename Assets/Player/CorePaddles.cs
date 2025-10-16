using System.Collections.Generic;
using UnityEngine;

public class CorePaddles : MonoBehaviour
{
    [SerializeField] GameObject paddlePrefab;
    public List<GameObject> paddles;
    void Start()
    {
        GameObject newPaddle = Instantiate(paddlePrefab, transform);
        paddles.Add(newPaddle);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject paddle in paddles)
        {
            paddle.transform.position = transform.position + transform.forward * 2;
            paddle.transform.rotation = transform.rotation;
        }
    }
}
