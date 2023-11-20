using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnPoint;
    public float minForce = 5f;
    public float maxForce = 10f;
    public float spawnDelay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnObjectsWithDelay());
    }

    IEnumerator SpawnObjectsWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (objectsToSpawn.Length > 0)
            {
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                GameObject objectToSpawn = objectsToSpawn[randomIndex];

                if (spawnPoint != null)
                {
                    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                    Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        float forceMagnitude = Random.Range(minForce, maxForce);
                        rb.AddForce(spawnPoint.forward * forceMagnitude, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}
