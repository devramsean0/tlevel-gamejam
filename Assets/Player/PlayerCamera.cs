using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject playerPaddle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPaddle.transform.position + new Vector3(0, 10, 0);
    }
}
