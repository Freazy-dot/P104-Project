using System.Collections;
using UnityEngine;

public class RandomFishSpawner : MonoBehaviour
{
    public int numberOfObjectsToSpawn = 5; // Number of objects to spawn
    public GameObject[] objectsToSpawn; // List of GameObjects to spawn
    public Collider spawnArea; // Collider defining the spawn area

    void Start()
    {
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider not assigned!");
            return;
        }

        SpawnObjectsInsideCollider();
    }

    void SpawnObjectsInsideCollider()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Randomly select a GameObject from the list
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Random position within the collider
            Vector3 spawnPosition = GetRandomPositionInCollider();

            // Instantiate the selected object at the random position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionInCollider()
    {
        Vector3 spawnPosition = Vector3.zero;

        if (spawnArea != null)
        {
            // Generate a random point within the collider bounds
            Vector3 randomPoint = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            // Ensure the point is inside the collider by clamping it to the collider bounds
            spawnPosition = new Vector3(
                Mathf.Clamp(randomPoint.x, spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Mathf.Clamp(randomPoint.y, spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Mathf.Clamp(randomPoint.z, spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );
        }

        return spawnPosition;
    }
}
