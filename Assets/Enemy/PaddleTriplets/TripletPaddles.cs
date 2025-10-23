using System;
using UnityEngine;
using UnityEngine.AI;

public class TripletPaddles : MonoBehaviour
{
    [SerializeField] GameObject[] tripletPaddles;

    public Vector3 tripletsCentre;

    bool paddlesStillAlive;

    public GameObject waveHandler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tripletsCentre = tripletPaddles[0].transform.position + tripletPaddles[1].transform.position + tripletPaddles[2].transform.position;

        paddlesStillAlive = false;
        foreach (GameObject paddle in tripletPaddles)
        {
            if (paddle.GetComponent<IndividualTriplet>().alive == true)
            {
                if (!paddlesStillAlive)
                {
                    paddlesStillAlive = true;
                }
            }
        }
        if (!paddlesStillAlive)
        {
            waveHandler.GetComponent<WaveScript>().currentEnemiesAlive.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
