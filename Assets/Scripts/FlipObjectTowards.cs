using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObjectTowards : MonoBehaviour
{
    public GameObject objectToFlip;    // The object you want to flip
    public GameObject targetObject;    // The object you want to flip towards

    void Update()
    {
        if (objectToFlip != null && targetObject != null)
        {
            Vector3 direction = targetObject.transform.position - objectToFlip.transform.position;

            if (direction.x > 1)
            {
                // Flip the object to look right
                objectToFlip.transform.localScale = new Vector3(Mathf.Abs(objectToFlip.transform.localScale.x), objectToFlip.transform.localScale.y, objectToFlip.transform.localScale.z);
            }
            else if (direction.x < 1)
            {
                // Flip the object to look left
                objectToFlip.transform.localScale = new Vector3(-Mathf.Abs(objectToFlip.transform.localScale.x), objectToFlip.transform.localScale.y, objectToFlip.transform.localScale.z);
            }
        }
    }
}
