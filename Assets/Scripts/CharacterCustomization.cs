using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    List<Transform> slotOptionList = new List<Transform>();
    private int activeItem = 0;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Slot")
            {
                foreach (Transform grandChild in child)
                {

                    slotOptionList.Add(grandChild);
                    slotOptionList[0].gameObject.SetActive(true);

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
            

        //    foreach (Transform item in slotOptionList)
        //    {
        //        item.gameObject.SetActive(false);
        //    }
        //    activeItem++;

        //    if (activeItem > slotOptionList.Count -1)
        //    {
        //        activeItem = 0;
        //    }

        //    slotOptionList[activeItem].gameObject.SetActive(true);
            //Debug.Log(activeItem + " " + slotOptionList.Count);

            


        }

    public void NextOption()
    {
        foreach (Transform item in slotOptionList)
        {
            item.gameObject.SetActive(false);
        }
        activeItem++;

        if (activeItem > slotOptionList.Count - 1)
        {
            activeItem = 0;
        }

        slotOptionList[activeItem].gameObject.SetActive(true);
    }

}
