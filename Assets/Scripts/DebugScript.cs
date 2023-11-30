using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public bool Enabled = false;

    private void OnDebugSceneChange(InputValue value)
    {
        if (!Enabled) { return; }
        if (value.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    private void OnDebugSceneChange1(InputValue value)
    {
        if (!Enabled) { return; }
        if (value.isPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
