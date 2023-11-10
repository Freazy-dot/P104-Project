using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    // Player Movement Related
    [SerializeField] private float offset;
    [SerializeField] private float maxVel;
    [SerializeField] private float smoothTime;
    [SerializeField] private float minDistance;
    Vector2 currentVel;

    // Boundaries
    [SerializeField] public float yBoundary;
    [SerializeField] public float xBoundary;

    // User Specifications
    private float minScreenSize;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Steals the user's resolution and defines the smallest number into minScreenSize
        // We might run into problems if a user tries to change their resolution while playing lol
        minScreenSize = Mathf.Min(Screen.currentResolution.width, Screen.currentResolution.height);
    }

    // Update is called once per frame
    void Update()
    {
        // Defines the mouse position on the screen to the game world. 
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        
        // Defines the direction and distance to the mouse.
        Vector2 direction = ((Vector2)mouseWorldPosition - (Vector2)transform.position).normalized;
        float distance = Vector3.Distance(transform.position, mouseWorldPosition);
        
        // Defines a speed multiplier based on how far away the cursor is from the nearest screen edge
        // thereafter redefines baseVelocity via Lerp using the previous value, maxVel and the Clamp01
        // float that defined the distance from the nearest edge.
        float edgeSpeedMultiplier = Mathf.Clamp01((minScreenSize - Mathf.Min(Mathf.Abs(mouseWorldPosition.x), Mathf.Abs(mouseWorldPosition.y))) / minScreenSize);
        float baseVelocity = Mathf.Clamp01(distance / minDistance) * maxVel;
        baseVelocity = Mathf.Lerp(baseVelocity, maxVel, edgeSpeedMultiplier);

        if (distance > minDistance)
        {
            Vector2 targetPosition = (Vector2)transform.position + direction * (baseVelocity * Time.deltaTime);
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVel, smoothTime, maxVel);
            PlayArea();
        }
    }

    void PlayArea()
    {
        if (transform.position.x >= xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, 0);
        }
        else if (transform.position.x <= xBoundary * -1)
        {
            transform.position = new Vector3(xBoundary * -1, transform.position.y, 0);
        }
        if (transform.position.y >= yBoundary)
        {
            transform.position = new Vector3(transform.position.x, yBoundary, 0);
        }
        else if (transform.position.y <= yBoundary * -1)
        {
            transform.position = new Vector3(transform.position.x, yBoundary * -1, 0);
        }
    }
}
