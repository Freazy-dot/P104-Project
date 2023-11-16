using UnityEngine;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
    public List<GameObject> starPrefabs;  // The prefab of the object you want to spawn
    public int numberOfStars = 10;  // The number of objects to spawn
    public Collider spawnArea;  // The collider defining the spawning area

    void Start()
    {
        if (starPrefabs == null || starPrefabs.Count == 0)
        {
            Debug.LogError("Star prefabs not assigned! Please assign at least one prefab to the StarSpawner script.");
            return;
        }

        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider not assigned! Please assign a collider to the StarSpawner script.");
            return;
        }

        SpawnStars();
    }

    void SpawnStars()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            Vector3 randomSpawnPoint = GetRandomPointInCollider(spawnArea);

            // Pick a random star prefab from the list
            GameObject selectedStarPrefab = starPrefabs[Random.Range(0, starPrefabs.Count)];

            // Generate a random rotation
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Instantiate a new star at the random spawn point with a random rotation
            GameObject newStar = Instantiate(selectedStarPrefab, randomSpawnPoint, randomRotation);

            // You can do additional setup for the spawned object here if needed
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        // Get a random point within the collider bounds
        float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float randomY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        float randomZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}