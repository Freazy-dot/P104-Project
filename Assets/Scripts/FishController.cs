using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    public Transform[] waypoints; // Define waypoints for the fish to follow
    public float xScale = 0.2f; // Public variable for the x-axis scale
    private int currentWaypointIndex = 0;

    void Start()
    {
        SetWaypoint(0); // Start at the first waypoint
    }

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        // Calculate the direction to the next waypoint
        Vector3 targetDirection = (waypoints[currentWaypointIndex].position - transform.position).normalized;

        // Check if the fish is moving towards the left or right
        bool isMovingLeft = (targetDirection.x < 0);

        // Move the fish forward in the direction of the next waypoint
        transform.Translate(targetDirection * speed * Time.deltaTime);

        // Adjust the scale based on direction
        transform.localScale = new Vector3((isMovingLeft ? xScale : -xScale), transform.localScale.y, transform.localScale.z);

        // Check if the fish has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            // Move to the next waypoint or cycle back to the first waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            SetWaypoint(currentWaypointIndex);
            Debug.Log("Reached waypoint " + currentWaypointIndex);
        }
    }

    void SetWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            currentWaypointIndex = index;
        }
    }
}
