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

        float distancePlayer = Vector3.Distance(randPos, player.transform.position);
        float distanceFood = Vector3.Distance(randPos, GameObject.FindGameObjectWithTag("FishFood").transform.position);

        if (distancePlayer > 2 && distanceFood > 2)
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
