using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatingSpeed = 1.0f; // Adjust the speed of floating
    public float floatingHeight = 1.0f; // Adjust the height of floating

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on sine function to achieve the floating effect
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}