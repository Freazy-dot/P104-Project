using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class EnableDisableObject : MonoBehaviour
{
    public GameObject objectToEnableDisable;
    public float cooldownTime = 1.0f; // Cooldown time before space can be pressed again.

    private bool spaceBarPressed = false;
    private float timer = 0f;

    void Update()
    {
        if (!spaceBarPressed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceBarPressed = true;
                EnableObject();
            }
        }

        if (spaceBarPressed)
        {
            timer += Time.deltaTime;

            if (timer >= cooldownTime)
            {
                DisableObject();
                spaceBarPressed = false;
                timer = 0f;
            }
        }
    }

    void EnableObject()
    {
        if (objectToEnableDisable != null)
        {
            objectToEnableDisable.SetActive(true);
        }
    }

    void DisableObject()
    {
        if (objectToEnableDisable != null)
        {
            objectToEnableDisable.SetActive(false);
        }
    }
}

