using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private int foodSpawnCount;
    [SerializeField] private GameObject prefap;
    private GameObject player;
    [HideInInspector] public List<GameObject> foodList = new List<GameObject>();

    [Tooltip("default distance food")]
    [SerializeField] private float distanceFood = 4;

    private PlayerMovement pm;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        pm = player.GetComponent<PlayerMovement>();
        for (int i = 0; i < foodSpawnCount; i++)
        {
            SpawnFoodRandom();
        }
    }

    void SpawnFoodRandom()
    {
        float randX = Random.Range(pm.xLeftBoundary, pm.xRightBoundary);
        float randY = Random.Range(pm.yUpBoundary, pm.yDownBoundary);

        Vector3 randPos = new Vector3(randX, randY, 0);

        float distancePlayer = Vector3.Distance(randPos, player.transform.position);
        
        if (foodList.Count > 0)
        {
            float currDist;
            foreach (GameObject food in foodList)
            {
                currDist = Vector3.Distance(randPos, food.transform.position);
                if (currDist < distanceFood) { distanceFood = currDist; } //distance food will be closest food or default distancefood if no food close
            }
        }
        
        if (distancePlayer > 4 && distanceFood > 3)
        {
            GameObject fishFood = Instantiate(prefap, new Vector3(randX, randY, 0), Quaternion.identity);
            foodList.Add(fishFood);
            distanceFood = 100; //arbitrary high number will be overwritten in foreach loop
            return;
        }
        else
        {
            //Debug.Log($"distanceplayer {distancePlayer} distancefood {distanceFood}");
            distanceFood = 100; //arbitrary high number will be overwritten in foreach loop
        }
        SpawnFoodRandom();
    }
    private void Update()
    {
      
    }

    public void removeFromList (GameObject removeObject)
    {
        foodList.Remove(removeObject);
        //Destroy(removeObject);
        removeObject.SetActive(false);
    }
}
