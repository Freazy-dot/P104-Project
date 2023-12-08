using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Tooltip("Only used on start menu to enable")]
    public GameObject objectToEnable; // Reference to the GameObject to enable


    private void Start()
    {
        Debug.Log(GameObject.FindWithTag("Player"));
        if (GameObject.FindWithTag("Player") != null)
        {
            Transform playerRoot = GameObject.FindWithTag("Player").transform.root;
            Destroy(playerRoot.gameObject);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
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
