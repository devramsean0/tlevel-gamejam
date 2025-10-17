using System.Collections.Generic;
using UnityEngine;

public class CorePaddles : MonoBehaviour
{
    [SerializeField] GameObject paddlePrefab;
    public List<GameObject> paddles;
    void Start()
    {
        GameObject newPaddle = Instantiate(paddlePrefab);
        newPaddle.transform.position = transform.position + transform.forward * 2f;
        newPaddle.GetComponent<PaddleMain>().rotationOffset = transform.rotation.y;
        paddles.Add(newPaddle);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject paddle in paddles)
        {
            paddle.GetComponent<PaddleMain>().intendedLocation = transform.position + transform.forward * 2f;
            paddle.GetComponent<PaddleMain>().rotationOffset = transform.rotation.eulerAngles.y;
        }
    }
}
