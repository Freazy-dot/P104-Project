using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public Transform target; // The target game object to look at

    private void Update()
    {
        if (target != null)
        {
            // Make this game object's transform look at the target's position
            transform.LookAt(target);
        }
    }
}
