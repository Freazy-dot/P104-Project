using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FishEat : MonoBehaviour
{
    public int foodCounter;
    public TMP_Text text;
    
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
        }
    }
}
