using UnityEngine;

public class MoveObjectToLeft : MonoBehaviour
{
    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float leftSpeed = 5f; // Public speed value to move the object to the left

    void Start()
    {
        if (rb == null)
        {
            // If the Rigidbody2D is not assigned, try to get it from the same GameObject
            rb = GetComponent<Rigidbody2D>();

            // If it's still null, log an error
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component not found!");
            }
        }
    }

    void Update()
    {
        MoveToLeft();
    }

    void MoveToLeft()
    {
        // Check if the Rigidbody2D component is assigned
        if (rb != null)
        {
            // Set the velocity to move the object to the left
            rb.velocity = new Vector2(-leftSpeed, rb.velocity.y);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found!");
        }
    }
}
