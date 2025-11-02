using UnityEngine;

public class ImpactFlash : MonoBehaviour
{
    [SerializeField] Material impactFlashMaterial;
    float impactFlashTimeLeft = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckForRenderer(transform);
    }

    void CheckForChildren(Transform parentObject)
    {
        Debug.Log(parentObject.childCount);
        if (parentObject.childCount > 0)
        {
            for (int i = 0; i < parentObject.childCount; i++)
            {
                CheckForRenderer(parentObject.GetChild(i));
            }
        }
    }
    
    void CheckForRenderer(Transform objectToCheck)
    {
        if (objectToCheck.GetComponent<Renderer>() && objectToCheck.GetComponent<Renderer>().material != impactFlashMaterial)
        {
            objectToCheck.GetComponent<Renderer>().material = impactFlashMaterial;
        }
        CheckForChildren(objectToCheck);
    }
}
