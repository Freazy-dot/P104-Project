using System.Collections;
using UnityEngine;

public class DisableMouse : MonoBehaviour
{
    public float disableTime = 5.0f; // Set the time to disable the mouse

    void Start()
    {
        // Start the coroutine to disable the mouse for the specified time
        StartCoroutine(DisableMouseForTime());
    }

    IEnumerator DisableMouseForTime()
    {
        // Disable the mouse cursor and input
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Wait for the specified time
        yield return new WaitForSeconds(disableTime);

        // Enable the mouse cursor and input again
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
