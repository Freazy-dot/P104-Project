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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // defines the position of the mouse relative to the user's screen and relative to the game world.
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition + Vector3.forward * 10f);

        // rotates the user towards the cursor 
        Quaternion rot = Quaternion.LookRotation(mouseWorldPosition - transform.position, Vector3.right) * Quaternion.Euler(offset, 0, 0);
        transform.rotation = rot;

        float distance = Vector3.Distance(transform.position, mouseWorldPosition);

        if (distance > minDistance)
        {
            // defines two adjustedMaxVel variables that takes into account the distance between the player and the cursor
            // in relation to the user's screen resolution. 
            float distanceToEdgeX = Mathf.Min(Mathf.Abs(mouseScreenPosition.x), Mathf.Abs(Screen.width - mouseScreenPosition.x));
            float distanceToEdgeY = Mathf.Min(Mathf.Abs(mouseScreenPosition.y), Mathf.Abs(Screen.height - mouseScreenPosition.y));

            float adjustedMaxVelX = maxVel;
            float adjustedMaxVelY = maxVel;

            // ensures that when the user's cursor exceeds the smallest value of their screen resolution,
            // the player continues at maxVel instead of slowing down.
            if (distanceToEdgeX > 0.5f * Screen.width)
            {
                adjustedMaxVelX *= 1 / Mathf.Clamp01(distanceToEdgeX / (0.5f * Screen.width));
            }

            if (distanceToEdgeY > 0.5f * Screen.height)
            {
                adjustedMaxVelY *= 1 / Mathf.Clamp01(distanceToEdgeY / (0.5f * Screen.height));
            }

            // does the movement stuff
            float adjustedMaxVel = Mathf.Max(adjustedMaxVelX, adjustedMaxVelY);

            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            mouseWorldPosition2D += ((Vector2)transform.position - mouseWorldPosition2D).normalized * minDistance;

            transform.position = Vector2.SmoothDamp(transform.position, mouseWorldPosition2D, ref currentVel, smoothTime, adjustedMaxVel);
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
