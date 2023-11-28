using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int endScene;
    [SerializeField] public float yBoundary;
    [SerializeField] public float xBoundary;
    [SerializeField] private int foodGoal = 4; //default val
    [SerializeField] private float countdownTimer = 10.0f; // Set the initial countdown time
    [SerializeField] private GameObject objectToActivate; // Reference to the GameObject to activate
    [SerializeField] private List<GameObject> objectsToDisable; // List of GameObjects to disable

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerMovement>().xBoundary = xBoundary;
        player.GetComponent<PlayerMovement>().yBoundary = yBoundary;
    }

    private void Start()
    {
        player.transform.position = Vector3.zero;
        player.GetComponent<FishEat>().foodCounter = 0;
        player.GetComponent<FishEat>().foodGoal = foodGoal;
        player.GetComponent<FishEat>().goalCompleted = false;
    }

    void Update()
    {
        // Decrement the countdown timer
        countdownTimer -= Time.deltaTime;

        // Check if the food goal has been achieved
        if (player.GetComponent<FishEat>().foodCounter >= foodGoal)
        {
            // Check if the countdown timer has reached 0
            if (countdownTimer <= 0.0f)
            {
                SceneChange();
                ActivateObject();
                DisableObjects();
            }
        }
    }

    public void SceneChange()
    {
        if (SceneManager.GetActiveScene().buildIndex == endScene)
        {
            Debug.Log("haha u won idiott pls close game");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ActivateObject()
    {
        // Check if the objectToActivate is assigned
        if (objectToActivate != null)
        {
            // Activate the specified GameObject
            objectToActivate.SetActive(true);
        }
    }

    private void DisableObjects()
    {
        // Disable all GameObjects in the list
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
