using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFreezeAndEnable : MonoBehaviour
{
    public List<GameObject> objectsToEnable;
    public List<GameObject> objectsToDisable;
    public Button unfreezeButton;

    public List<GameObject> objectsToEnableOnEscape;
    public List<GameObject> objectsToDisableOnEscape;

    private bool gameIsFrozen = true;

    void Start()
    {
        // Freeze the game at the start
        Time.timeScale = 0;

        if (unfreezeButton != null)
        {
            unfreezeButton.onClick.AddListener(UnfreezeGame);
        }
        else
        {
            Debug.LogWarning("Unfreeze Button is not assigned. Make sure to assign it in the inspector.");
        }
    }

    void Update()
    {
        // Check if the Escape key is pressed to freeze/unfreeze the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsFrozen)
            {
                UnfreezeGame();
                Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
                Cursor.visible = false; // Hide the cursor
            }
            else
            {
                FreezeGame();
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
                Cursor.visible = true; // Show the cursor
            }
        }
    }

    private void FreezeGame()
    {
        // Disable specified objects when the game is frozen
        foreach (var obj in objectsToDisableOnEscape)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 0; // Freeze the game
        gameIsFrozen = true;

        // Enable specified objects
        foreach (var obj in objectsToEnableOnEscape)
        {
            obj.SetActive(true);

            // If the object is a Button, set its interactable state to true
            Button button = obj.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
            }
        }
    }

    private void UnfreezeGame()
    {
        // Disable specified objects when the button is pressed
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 1; // Unfreeze the game
        gameIsFrozen = false;

        // Enable specified objects
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        // Disable the unfreeze button
        if (unfreezeButton != null)
        {
            unfreezeButton.interactable = false;
        }
    }
}
