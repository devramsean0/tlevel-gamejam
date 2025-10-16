using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject playerCore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCore.transform.position + new Vector3(0, 10, 0);
    }
}
