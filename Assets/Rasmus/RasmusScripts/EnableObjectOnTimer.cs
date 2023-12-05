using UnityEngine;

public class EnableObjectOnTimer : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to be enabled
    public float timerInSeconds = 5f; // The time in seconds

    private float countdownTimer;

    void Start()
    {
        countdownTimer = timerInSeconds;
    }

    void Update()
    {
        // Countdown the timer
        countdownTimer -= Time.deltaTime;

        // Check if the timer has reached zero
        if (countdownTimer <= 0f)
        {
            // Enable the targetObject and reset the timer
            if (targetObject != null)
            {
                targetObject.SetActive(true);
                countdownTimer = timerInSeconds; // Reset the timer for future use
            }
            else
            {
                Debug.LogError("Target Object is not assigned!");
            }
        }
    }
}