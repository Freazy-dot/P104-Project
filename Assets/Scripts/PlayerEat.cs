using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FishEat : MonoBehaviour
{
    [HideInInspector] public bool goalCompleted = false;
    [HideInInspector] public int foodCounter;
    private TMP_Text text;
    //[SerializeField] private TMP_Text NoMoreFood;
    [HideInInspector] public int foodGoal;

    public GameObject lvlManager;//fuix later

    private LevelManager lvm;
    private FoodSpawn fs;
    
    void Start()
    {
        lvm = lvlManager.GetComponent<LevelManager>();
        fs = lvlManager.GetComponent<FoodSpawn>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider col)
    {
        if (text == null) { text = GameObject.FindWithTag("FoodCounter").GetComponent<TMP_Text>(); }
        

        GameObject food = col.gameObject;
        if (food.CompareTag("FishFood"))
        {
            fs.removeFromList(food);

            foodCounter++;
            text.SetText("Food eaten: " + foodCounter);
            OnEat(foodCounter);
        }
    }

    void OnEat(int foodCounter)
    {
        if (foodCounter >= foodGoal && !goalCompleted)
        {
            //change scene
            
            Debug.Log("you did it dumbasss");
            //NoMoreFood.SetText("No More Food Left");
            goalCompleted = true;
            lvm.SceneChange();
        }
    }
}
