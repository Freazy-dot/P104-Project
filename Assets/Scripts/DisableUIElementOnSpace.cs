using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DisableUIElementOnSpace : MonoBehaviour
{
    public GameObject uiElementToDisable; // Reference to the UI element to disable

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if the UI element is not null
            if (uiElementToDisable != null)
            {
                // Disable the UI element
                uiElementToDisable.SetActive(false);
            }
        }
    }
}

