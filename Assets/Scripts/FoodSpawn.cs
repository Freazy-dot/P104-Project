using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private int foodSpawnCount;

    [SerializeField] private GameObject prefap;

    [SerializeField] private GameObject player;

    private PlayerMovement pm;
    
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        for (int i = 0; i < foodSpawnCount; i++)
        {
            SpawnFoodRandom();
        }
        
    }

    void SpawnFoodRandom()
    {
        float randX = Random.Range(pm.xBoundary * -1, pm.xBoundary);
        float randY = Random.Range(pm.yBoundary * -1, pm.yBoundary);

        Vector3 randPos = new Vector3(randX, randY, 0);

        float distance = Vector3.Distance(randPos, player.transform.position);

        if (distance > 2)
        {
            Instantiate(prefap, new Vector3(randX, randY, 0), Quaternion.identity);
        }
        else
        {
            SpawnFoodRandom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
