using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FishEat : MonoBehaviour
{
    private bool goalCompleted = false;
    private int foodCounter;
    [SerializeField] private TMP_Text text;
    [SerializeField] private int foodGoal;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        GameObject food = col.gameObject;
        if (food.CompareTag("FishFood"))
        {
            Destroy(food);
            foodCounter++;
            text.SetText("Food Eaten: " + foodCounter);
            OnEat(foodCounter);
        }
    }

    void OnEat(int foodCounter)
    {
        if (foodCounter >= foodGoal && !goalCompleted)
        {
            //change scene
            Debug.Log("you did it dumbasss");
            goalCompleted = true;
        }
    }
}
