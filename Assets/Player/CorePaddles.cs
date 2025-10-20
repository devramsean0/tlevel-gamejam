using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CorePaddles : MonoBehaviour
{
    [SerializeField] GameObject paddlePrefab;
    public List<GameObject> paddles;
    void Start()
    {
        NewPaddle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewPaddle()
    {
        GameObject newPaddle = Instantiate(paddlePrefab);
        newPaddle.transform.position = transform.position + transform.forward * 2f;
        newPaddle.GetComponent<PaddleMain>().rotationOffset = transform.rotation.y;
        Physics.IgnoreCollision(GetComponent<Collider>(), newPaddle.GetComponent<Collider>());
        paddles.Add(newPaddle);
        for (int i = 0; i < paddles.Count; i++)
        {
            paddles[i].GetComponent<PaddleMain>().extraRotationOffset = (360 / paddles.Count) * i;
            paddles[i].transform.rotation = Quaternion.Euler(new Vector3(0, paddles[i].GetComponent<PaddleMain>().rotationOffset + paddles[i].GetComponent<PaddleMain>().extraRotationOffset, 0));
        }
        
    }
}
