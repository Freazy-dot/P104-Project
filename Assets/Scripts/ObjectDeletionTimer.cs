using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletionTimer : MonoBehaviour
{
    public float deletionTime = 5.0f; // Time in seconds before the object is deleted

    void Start()
    {
        // Schedule the object for deletion after a specific time
        Invoke("DeleteObject", deletionTime);
    }

    public void DeleteObject()
    {
        // This method is called after 'deletionTime' seconds
        Destroy(gameObject);
    }
}

