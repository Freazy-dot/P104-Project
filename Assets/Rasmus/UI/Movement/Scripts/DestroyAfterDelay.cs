using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public List<GameObject> objectsToDestroy;
    public List<GameObject> objectsToEnable;
    public float delayBeforeDestroy = 5.0f; // Set the time before destruction

    void Start()
    {
        // Start the coroutine to enable the objects after the specified delay and destroy the objectsToDestroy
        StartCoroutine(EnableListAfterDestroyCoroutine());
    }

    IEnumerator EnableListAfterDestroyCoroutine()
    {
        // Wait for the specified delay before destroying the objectsToDestroy
        yield return new WaitForSeconds(delayBeforeDestroy);

        // Destroy each object in the list if it is not null
        foreach (var objToDestroy in objectsToDestroy)
        {
            if (objToDestroy != null)
            {
                Destroy(objToDestroy);
            }
        }

        // Wait for one frame to ensure the objects are destroyed before enabling the new objects
        yield return null;

        // Enable each object in the list if it is not null
        foreach (var objToEnable in objectsToEnable)
        {
            if (objToEnable != null)
            {
                objToEnable.SetActive(true);
            }
        }
    }
}
