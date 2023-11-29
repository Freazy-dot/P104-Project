using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int endScene;

    [SerializeField] private Transform yUpBoundary;
    [SerializeField] private Transform yDownBoundary;
    [SerializeField] private Transform xLeftBoundary;
    [SerializeField] private Transform xRightBoundary;


    [SerializeField] private int foodGoal = 4; //default val
    [SerializeField] private float countdownTimer = 4.4f; // Set the initial countdown time
    [SerializeField] private GameObject objectToActivate; // Reference to the GameObject to activate
    [SerializeField] private List<GameObject> objectsToDisable; // List of GameObjects to disable

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = Vector3.zero;
        player.GetComponent<PlayerMovement>().xRightBoundary = xRightBoundary.position.x;
        player.GetComponent<PlayerMovement>().xLeftBoundary = xLeftBoundary.position.x;
        player.GetComponent<PlayerMovement>().yUpBoundary = yUpBoundary.position.y;
        player.GetComponent<PlayerMovement>().yDownBoundary = yDownBoundary.position.y;
    }

    private void Start()
    {
        player.transform.position = Vector3.zero;
        player.GetComponent<FishEat>().foodCounter = 0;
        player.GetComponent<FishEat>().foodGoal = foodGoal;
        player.GetComponent<FishEat>().goalCompleted = false;

        endScene = SceneManager.sceneCountInBuildSettings - 1;//index start at 0 omg lol haha
    }

    void Update()
    {
        //Debug.Log($"scene = {SceneManager.GetActiveScene().buildIndex} and end scene = {endScene}");
        // Decrement the countdown timer


        // Check if the food goal has been achieved
        if (player.GetComponent<FishEat>().foodCounter >= foodGoal)
        {
            ActivateObject();
            DisableObjects();
            countdownTimer -= Time.deltaTime;
            player.GetComponent<PlayerXRay>().canXray = false;
            //Debug.Log(countdownTimer);
            // Check if the countdown timer has reached 0
            if (countdownTimer <= 0.0f)
            {
               // Debug.Log("in " + countdownTimer);
                SceneChange();
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
