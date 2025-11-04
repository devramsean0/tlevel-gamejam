using UnityEngine;

public class CoreMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallMain>())
        {
            transform.parent.parent.GetComponent<PlayerStats>().currentHealth -= collision.gameObject.GetComponent<BallMain>().ballStats.damage;
            Destroy(collision.gameObject);
        }
    }
}
