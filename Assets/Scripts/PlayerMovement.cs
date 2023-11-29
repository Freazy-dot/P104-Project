using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    private CameraScript camScript;

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
    [HideInInspector] public float yUpBoundary;
    [HideInInspector] public float yDownBoundary;
    [HideInInspector] public float xLeftBoundary;
    [HideInInspector] public float xRightBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camScript = Camera.main.gameObject.GetComponent<CameraScript>();
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        // mouse on screen pos and in world
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition + Vector3.forward * ((camScript.zOffset) * -1));

        // actually rotate player
        Quaternion rot = Quaternion.LookRotation(mouseWorldPosition - transform.position, Vector3.down) * Quaternion.Euler(offset, 0, 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * degreesPerSecond);






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
            //Debug.Log("angle " + angle);
            //Debug.Log("maxvel " +  adjustedMaxVel);

            
            transform.position = Vector2.SmoothDamp(transform.position, mouseWorldPosition2D, ref currentVel, smoothTime, adjustedMaxVel);
            
            PlayArea();
        }
    }

    void PlayArea()
    {
        if (transform.position.x >= xRightBoundary)
        {
            transform.position = new Vector3(xRightBoundary, transform.position.y, 0);
        }
        else if (transform.position.x <= xLeftBoundary)
        {
            transform.position = new Vector3(xLeftBoundary, transform.position.y, 0);
        }
        if (transform.position.y >= yUpBoundary)
        {
            transform.position = new Vector3(transform.position.x, yUpBoundary, 0);
        }
        else if (transform.position.y <= yDownBoundary)
        {
            transform.position = new Vector3(transform.position.x, yDownBoundary, 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        //if(collision.gameObject.tag != "Border") {  return; }
        //transform.position = new Vector3(collision.transform.position.x + 0.5f, transform.position.y, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Border") { return; }

        //transform.position = new Vector3(collision.transform.position.x + 0.5f, transform.position.y, 0);
    }
}
