using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Collider triggerCollider; // The collider that checks for tags
    public string endTag = "End"; // The tag to check for
    public List<GameObject> objectsToDeactivate; // List of objects to deactivate
    public List<GameObject> objectsToActivate; // List of objects to activate

    private bool inEndZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(endTag))
        {
            inEndZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(endTag))
        {
            inEndZone = false;
        }
    }

    private void Update()
    {
        if (inEndZone && Input.GetKeyDown(KeyCode.Space))
        {
            // Deactivate objects in the list
            foreach (var obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }

            // Activate objects in the list
            foreach (var obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}




