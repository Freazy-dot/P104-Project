using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject objectToEnable; // Reference to the GameObject to enable

    public void EndGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        // Enable the GameObject immediately
        objectToEnable.SetActive(true);

        // Use Invoke to delay the scene change
        Invoke("ChangeScene", 0.35f);
    }

    private void ChangeScene()
    {
        // Get the next scene index and load the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
