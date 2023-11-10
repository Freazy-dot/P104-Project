using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    private int screenSizeX;
    private int screenSizeY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        screenSizeX = Screen.currentResolution.width;
        screenSizeY = Screen.currentResolution.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);


        Quaternion rot = Quaternion.LookRotation(mouseWorldPosition - transform.position, Vector3.right) * Quaternion.Euler(offset, 0, 0);
        
        //rotate player to mouse
        transform.rotation = rot;
        
        //Movement
        float distance = Vector3.Distance(transform.position, mouseWorldPosition);
        
        if (distance > minDistance)
        {
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            mouseWorldPosition2D += ((Vector2)transform.position - mouseWorldPosition2D).normalized * minDistance;
            
            transform.position = Vector2.SmoothDamp(transform.position, mouseWorldPosition2D, ref currentVel, 0.3f, maxVel);
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