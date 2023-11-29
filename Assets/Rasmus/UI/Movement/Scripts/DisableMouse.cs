using System.Collections;
using UnityEngine;

public class DisableMouse : MonoBehaviour
{
    public float disableTime = 5.0f; // Set the time to disable the mouse
    private bool allowMouseInput = false;
    private PlayerMovement pm;
    private PlayerXRay px;

    void Start()
    {
        // Start the coroutine to disable the mouse for the specified time

        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        px = pm.gameObject.GetComponent<PlayerXRay>();
        StartCoroutine(DisableMouseForTime());

        
    }

    void Update()
    {
        //// Check if mouse input is allowed
        //if (!allowMouseInput)
        //{
        //    // Clear mouse button input
        //    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) ||
        //        Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        //    {
        //        // Do nothing or add additional actions as needed
        //    }
        //}
    }

    IEnumerator DisableMouseForTime()
    {
        //// Disable the mouse cursor and input


        //// Disable mouse buttons
        //allowMouseInput = false;

        //// Wait for the specified time
        //yield return new WaitForSeconds(disableTime);

        //// Enable the mouse cursor and input again
        

        //// Enable mouse buttons
        //allowMouseInput = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pm.canMove = false;
        px.canXray = false;
        yield return new WaitForSeconds(disableTime);
        pm.canMove = true;
        px.canXray = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
