using UnityEngine;

[RequireComponent(typeof(EnemyShooting))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyStats))]
public class IndividualTriplet : MonoBehaviour
{
    public bool alive;
    public float timeUntilRespawn;

    Rigidbody rb;
    LineRenderer lineRenderer;
    void Start()
    {
        alive = true;
        rb = GetComponent<Rigidbody>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(new Vector3[]{transform.position, transform.parent.GetComponent<TripletPaddles>().tripletsCentre});
        if (!alive)
        {
            timeUntilRespawn -= Time.deltaTime;
            rb.linearVelocity = new Vector3(0,0,0);
        }
        if (!alive && timeUntilRespawn <= 0f)
        {
            TripletAlive(true);
        }
        KeepPositionInRange();
    }

    public void TripletAlive(bool isAlive)
    {
        if (alive != isAlive) //stops the function running unneccesarily
        {
            alive = isAlive;
            GetComponent<Renderer>().enabled = isAlive;
            GetComponent<Collider>().enabled = isAlive;
            GetComponent<EnemyShooting>().enabled = isAlive;
            GetComponent<LineRenderer>().enabled = isAlive;
            if (isAlive)
            {
                GetComponent<EnemyStats>().enemyInfo.currentHealth = GetComponent<EnemyStats>().enemyInfo.maxHealth;
            }
            else
            {
                timeUntilRespawn = 5f;
            }
        }
    }

    void KeepPositionInRange()
    {
        Vector3 calculatedPosition = transform.position + rb.linearVelocity;
        Vector3 minPositionAllowed = transform.parent.GetComponent<TripletPaddles>().tripletsCentre - new Vector3(5f, 5f, 5f);
        Vector3 maxPositionAllowed = transform.parent.GetComponent<TripletPaddles>().tripletsCentre + new Vector3(5f, 5f, 5f);

        calculatedPosition = new Vector3(
            KeepAxisInRange(calculatedPosition.x, minPositionAllowed.x, maxPositionAllowed.x),
            KeepAxisInRange(calculatedPosition.y, minPositionAllowed.y, maxPositionAllowed.y),
            KeepAxisInRange(calculatedPosition.z, minPositionAllowed.z, maxPositionAllowed.z)
            );

        rb.linearVelocity = calculatedPosition - transform.position;
    }

    float KeepAxisInRange(float calculatedPositionAxis, float minPositionAxis, float maxPositionAxis)
    {
        if (calculatedPositionAxis < minPositionAxis)
        {
            calculatedPositionAxis = minPositionAxis;
        }
        else if (calculatedPositionAxis > maxPositionAxis)
        {
            calculatedPositionAxis = maxPositionAxis;
        }
        return calculatedPositionAxis;
    }
}
