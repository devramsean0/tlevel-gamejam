using System;
using System.Collections.Generic;
using UnityEngine;

public class ImpactFlash : MonoBehaviour
{
    [SerializeField] Material impactFlashMaterial;
    float impactFlashTimeLeft = 0f;

    public List<ObjectMaterials> objectMaterialsList = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (impactFlashTimeLeft > 0)
        {
            impactFlashTimeLeft -= Time.deltaTime;
            if (impactFlashTimeLeft <= 0)
            {
                impactFlashTimeLeft = 0f;
                ReturnToPrevMat();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        objectMaterialsList = new();
        CheckForRenderer(transform);
        impactFlashTimeLeft = 0.1f;
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
            List<Material> materials = new();
            List<Material> impactFlashMaterials = new();
            for (int i = 0; i < objectToCheck.GetComponent<Renderer>().materials.Length; i++)
            {
                materials.Add(objectToCheck.GetComponent<Renderer>().materials[i]);
                impactFlashMaterials.Add(impactFlashMaterial);
            }
            objectToCheck.GetComponent<Renderer>().SetMaterials(impactFlashMaterials);
            objectMaterialsList.Add(new ObjectMaterials(objectToCheck.GetComponent<Renderer>(), materials));
        }
        CheckForChildren(objectToCheck);
    }

    void ReturnToPrevMat()
    {
        foreach (ObjectMaterials objectMaterials in objectMaterialsList)
        {
            for (int i = 0; i < objectMaterials.objectRenderer.materials.Length; i++)
            {
                objectMaterials.objectRenderer.SetMaterials(objectMaterials.materials);
            }
        }
        objectMaterialsList = new();
    }


    [Serializable]
    public class ObjectMaterials
    {
        public Renderer objectRenderer;
        public List<Material> materials;

        public ObjectMaterials(Renderer objectRenderer, List<Material> materials)
        {
            this.objectRenderer = objectRenderer;
            this.materials = materials;
        }
    }
}
