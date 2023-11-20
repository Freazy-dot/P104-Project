using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class ObjectFloating : MonoBehaviour
{
    public float floatSpeed = 1.0f; // Adjust this value to control the speed of the float.
    public float floatAmplitude = 1.0f; // Adjust this value to control the height of the float.

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on a sine wave.
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Update the object's position to create the floating effect.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

