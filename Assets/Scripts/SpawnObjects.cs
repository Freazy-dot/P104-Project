using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> objectList; // List of objects to spawn
    public TMP_Text uiText; // Reference to your first TextMeshPro UI element
    public TMP_Text secondUiText; // Reference to your second TextMeshPro UI element
    public TMP_Text thirdUiText; // Reference to your third TextMeshPro UI element
    public List<GameObject> gameObjectsToDisable; // List of GameObjects to disable
    public Button uiButton; // Reference to your UI button
    public float spawnDelay = 2.0f; // Delay between spawns
    public float spawnRadius = 5.0f; // Radius within which objects can spawn
    public float timer = 10.0f; // Timer in seconds

    private int currentCount = 0; // Current count from the first UI element
    private int lastCount = 0; // Previous count
    private float lastSpawnTime = 0.0f;
    private bool spawningStarted = false;

    void Start()
    {
        // Disable the GameObjects in the list at the beginning
        foreach (GameObject obj in gameObjectsToDisable)
        {
            obj.SetActive(false);
        }

        // Disable the UI button at the beginning
        uiButton.gameObject.SetActive(false);

        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        spawningStarted = true;
    }

    void Update()
    {
        if (spawningStarted)
        {
            // Parse the text from the first TextMeshPro UI element to an integer
            if (int.TryParse(uiText.text, out currentCount))
            {
                // Check if the current count is greater than the last count in increments of 5
                if (currentCount >= lastCount + 5)
                {
                    int numberOfObjectsToSpawn = (currentCount - lastCount) / 5;
                    StartCoroutine(SpawnObjectsWithDelay(numberOfObjectsToSpawn));
                    lastCount = currentCount;
                }
            }

            int secondCount = 0;
            if (int.TryParse(secondUiText.text, out secondCount))
            {
                // Check if the second TextMeshPro count matches the first TextMeshPro count
                if (secondCount == currentCount)
                {
                    // Activate the third TextMeshPro element
                    thirdUiText.gameObject.SetActive(true);

                    // Enable the UI button after 2 seconds
                    StartCoroutine(EnableUIButtonAfterDelay(2.0f));
                }
            }
        }
    }

    IEnumerator SpawnObjectsWithDelay(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnRandomObject()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        int randomIndex = Random.Range(0, objectList.Count);
        GameObject spawnedObject = Instantiate(objectList[randomIndex], randomPosition, Quaternion.identity);

        // Increment the second TextMeshPro UI element by 5
        int secondCount = 0;
        if (int.TryParse(secondUiText.text, out secondCount))
        {
            secondCount += 5;
            secondUiText.text = secondCount.ToString();
        }

        lastSpawnTime = Time.time;
    }

    IEnumerator EnableUIButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        uiButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
    }

    // Override the Escape key behavior
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Do nothing when the script is active
        }
    }
}
