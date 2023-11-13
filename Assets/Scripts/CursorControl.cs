using UnityEngine;
using UnityEngine.UI;

public class MouseCursorController : MonoBehaviour
{
    public Button hideMouseCursorButton; // Reference to the UI button in the Inspector

    private void Start()
    {
        // Ensure the button is not null and add an onClick listener
        if (hideMouseCursorButton != null)
        {
            hideMouseCursorButton.onClick.AddListener(HideMouseCursor);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMouseCursor();
        }
    }

    public void HideMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    public void ShowMouseCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Release the cursor
        Cursor.visible = true; // Show the cursor
    }
}
