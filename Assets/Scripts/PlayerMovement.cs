using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float offset;

    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;

    [SerializeField] private float minDistance;

    Vector2 currentVel;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
            //Mouse Position in the world. It's important to give it some distance from the camera. 
            //If the screen point is calculated right from the exact position of the camera, then it will
            //just return the exact same position as the camera, which is no good.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

            //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

            
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + offset));
        



        float AngleBetweenPoints(Vector2 a, Vector2 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }



    }

    void FixedUpdate()
    {

        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector3.Distance(transform.position, targetPos);

        Debug.Log(distance);

        if(distance > minDistance)
        {
            targetPos += ((Vector2)transform.position - targetPos).normalized * minDistance;

            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref currentVel, 0.3f, speed);
        }
        

        
    }


}
