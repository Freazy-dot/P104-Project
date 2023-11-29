using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public GameObject spawner;  // Reference to the spawner GameObject
    public List<GameObject> objectsToSpawn;  // List of objects to spawn
    public float spawnForce = 10f;  // Force applied to the spawned objects in the -x direction
    public float spawnInterval = 2f;  // Interval between spawns in seconds
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 1f);  // Minimum scale for spawned objects
    public Vector3 maxScale = new Vector3(2f, 2f, 1f);  // Maximum scale for spawned objects
    public float destroyTimer = 5f;  // Time before the spawned object is destroyed

    private void Start()
    {
        // Invoke the SpawnObject method at regular intervals
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Ensure there are objects in the list
        if (objectsToSpawn.Count > 0)
        {
            // Select a random object from the list
            int randomIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawner.transform.position, Quaternion.identity);

            // Apply force to the spawned object in the -x direction
            Rigidbody2D objectRigidbody = spawnedObject.GetComponent<Rigidbody2D>();
            if (objectRigidbody != null)
            {
                objectRigidbody.AddForce(Vector2.left * spawnForce, ForceMode2D.Impulse);
            }

            // Set a random scale for the spawned object
            Vector3 randomScale = new Vector3(Random.Range(minScale.x, maxScale.x), Random.Range(minScale.y, maxScale.y), 1f);
            spawnedObject.transform.localScale = randomScale;

            // Destroy the spawned object after the specified time
            Destroy(spawnedObject, destroyTimer);
        }
    }
}
