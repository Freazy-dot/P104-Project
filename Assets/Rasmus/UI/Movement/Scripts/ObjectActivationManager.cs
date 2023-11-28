using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationManager : MonoBehaviour
{
    public List<GameObject> objectsToDisable;
    public List<GameObject> objectsToEnable;

    public float activationTime = 5.0f; // Set the time after which objects should be enabled

    void Start()
    {
        // Enable the initial objects when the game starts
        EnableObjects(objectsToDisable);

        // Start a coroutine to wait for the specified time before switching to the new objects
        StartCoroutine(SwitchObjectsAfterDelay());
    }

    void EnableObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }

    void DisableObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }

    IEnumerator SwitchObjectsAfterDelay()
    {
        // Wait for the specified activation time with the initial objects on the screen
        yield return new WaitForSeconds(activationTime);

        // Disable the initial objects
        DisableObjects(objectsToDisable);

        // Enable the new objects after the delay
        EnableObjects(objectsToEnable);
    }
}
