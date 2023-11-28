using System.Collections;
using UnityEngine;

public class EnableScriptAfterTime : MonoBehaviour
{
    public MonoBehaviour targetScript; // Reference to the script you want to enable
    public float disableTime = 2.0f; // Set the time to disable the script
    public float enableTime = 5.0f; // Set the time to enable the script

    void Start()
    {
        if (targetScript == null)
        {
            Debug.LogError("Target script is not assigned!");
            return;
        }

        // Disable the target script in the beginning
        targetScript.enabled = false;

        // Start the coroutine to enable the script after the specified times
        StartCoroutine(DisableAndEnableScript());
    }

    IEnumerator DisableAndEnableScript()
    {
        // Wait for the specified disable time
        yield return new WaitForSeconds(disableTime);

        // Enable the target script after the specified enable time
        yield return new WaitForSeconds(enableTime);
        targetScript.enabled = true;
    }
}
