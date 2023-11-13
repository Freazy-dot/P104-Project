using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    // Player Movement Related
    [Header("Movement")]
    [SerializeField] private float maxVel;
    [SerializeField] private float smoothTime;
    [SerializeField] private float minDistance;
    [SerializeField] private float LimitVelByRotScale = 15f; //bigger number less limit
    private Vector2 currentVel;

    //player rotation
    [Header("Rotation")]
    [SerializeField] private float degreesPerSecond = 90;
    [SerializeField] private float offset;
    

    // Boundaries
    [Header("Boundaries")]
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

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * degreesPerSecond);

        

        //transform.rotation = rot;





        float distance = Vector3.Distance(transform.position, mouseWorldPosition);

        if (distance > minDistance)
        {
            // defines two adjustedMaxVel and distanceToEdge variables that are used to measure the velocity
            // using the relation between the cursor, the edges and the player on both the y and x-axis.
            float distanceToEdgeX = Mathf.Min(Mathf.Abs(mouseScreenPosition.x), Mathf.Abs(Screen.width - mouseScreenPosition.x));
            float distanceToEdgeY = Mathf.Min(Mathf.Abs(mouseScreenPosition.y), Mathf.Abs(Screen.height - mouseScreenPosition.y));

            float adjustedMaxVelX = maxVel;
            float adjustedMaxVelY = maxVel;

            // ensures that when the user's cursor exceeds the smallest value of their screen resolution,
            // the player continues at maxVel instead of slowing down.
            if (distanceToEdgeX > 0.5f * Screen.width)
                adjustedMaxVelX *= 1 / Mathf.Clamp01(distanceToEdgeX / (0.5f * Screen.width));
            if (distanceToEdgeY > 0.5f * Screen.height)
                adjustedMaxVelY *= 1 / Mathf.Clamp01(distanceToEdgeY / (0.5f * Screen.height));

            // does the movement stuff
            float adjustedMaxVel = Mathf.Max(adjustedMaxVelX, adjustedMaxVelY);

            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            mouseWorldPosition2D += ((Vector2)transform.position - mouseWorldPosition2D).normalized * minDistance;

            
            
            //slow movement if need to rotate a lot spore like yep yep
            Vector2 dir = (mouseWorldPosition - transform.position).normalized;
            float angle = Mathf.Abs(Vector2.Angle(transform.up, dir));    
            adjustedMaxVel -= angle/LimitVelByRotScale;
            if(adjustedMaxVel < 0) { adjustedMaxVel = 0; }
            Debug.Log("angle " + angle);
            Debug.Log("maxvel " +  adjustedMaxVel);

            
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
