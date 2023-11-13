using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDashParticles : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f; // Adjust the duration as needed
    public ParticleSystem dashParticles;
    private bool isDashing = false;

    public float minXLimit = -5f; // Minimum X-axis limit
    public float maxXLimit = 5f; // Maximum X-axis limit
    public float minYLimit = -5f; // Minimum Y-axis limit
    public float maxYLimit = 5f; // Maximum Y-axis limit

    private bool isAEnabled = true; // A key input enabled
    private bool isDEnabled = true; // D key input enabled
    private bool isWEnabled = true; // W key input enabled
    private bool isSEnabled = true; // S key input enabled

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * (isDashing ? dashSpeed : moveSpeed) * Time.deltaTime;

        // Check for Dash input (Shift key)
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // Check for X-axis limits and disable 'A' and 'D' inputs
        float newX = transform.position.x + movement.x;
        if (newX < minXLimit)
        {
            isAEnabled = false; // Disable 'A' input
            newX = minXLimit;
        }
        else if (newX > maxXLimit)
        {
            isDEnabled = false; // Disable 'D' input
            newX = maxXLimit;
        }
        else
        {
            isAEnabled = true; // Enable 'A' input
            isDEnabled = true; // Enable 'D' input
        }

        // Check for Y-axis limits and disable 'W' and 'S' inputs
        float newY = transform.position.y + movement.y;
        if (newY < minYLimit)
        {
            isSEnabled = false; // Disable 'S' input
            newY = minYLimit;
        }
        else if (newY > maxYLimit)
        {
            isWEnabled = false; // Disable 'W' input
            newY = maxYLimit;
        }
        else
        {
            isWEnabled = true; // Enable 'W' input
            isSEnabled = true; // Enable 'S' input
        }

        // Apply X and Y-axis movement within limits
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    // Coroutine to handle dashing
    private IEnumerator Dash()
    {
        isDashing = true;
        dashParticles.Play(); // Start the Particle System
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        dashParticles.Stop(); // Stop the Particle System
    }
}
