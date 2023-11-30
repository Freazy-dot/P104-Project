using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomization : MonoBehaviour
{
    List<Transform> slotOptionList = new List<Transform>();

    //headslotthings
    private List<Transform> headOptionList = new List<Transform>();
    private int headItem = 0;

    //finslotthings
    private List<Transform> finOptionList = new List<Transform>();
    private int finItem = 0;

    //eyeslotthings

    void Start()
    {
        foreach (Transform child in transform) //get every child
        {
            if (child.tag == "Slot")//if child is tagged with slot
            {
                foreach (Transform grandChild in child)//the grandchildren will be the individual customization options nested under the empty gameobjects
                {
                    if(grandChild.gameObject.tag == "Head")//if a head option
                    {
                        headOptionList.Add(grandChild);//add to list of headoptions
                        headOptionList[0].gameObject.SetActive(true);//set the first option as active
                    }else if (grandChild.gameObject.tag == "SideFin")//repeat for sidefin
                    {
                        finOptionList.Add(grandChild);
                        finOptionList[0].gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.parent);
    }
    public void NextButton (string type)
    {
        switch (type)
        {
            case "Head":

                headItem++;
                if (headItem > headOptionList.Count - 1)
                {
                    headItem = 0;
                }

                EnableOnlyActiveItem(headOptionList, headItem);
                
                break;
            case "SideFin":
                finItem++;
                if (finItem > finOptionList.Count - 1)
                {
                    finItem = 0;
                }

                EnableOnlyActiveItem(finOptionList, finItem);
                break;


        }
    }

    public void PrevButton(string type)
    {
        switch (type)
        {
            case "Head":

                headItem--;

                if (headItem < 0)
                {
                    headItem = headOptionList.Count - 1;
                }

                EnableOnlyActiveItem(headOptionList, headItem);
                break;
            case "SideFin":
                finItem--;

                if (finItem < 0)
                {
                    finItem = finOptionList.Count - 1;
                }

                EnableOnlyActiveItem(finOptionList, finItem);
                break;


        }
    }

    private void EnableOnlyActiveItem(List<Transform> list, int listItem)
    {
        foreach (Transform item in list)
        {
            item.gameObject.SetActive(false);
        }

        list[listItem].gameObject.SetActive(true);
    }

    public void SceneChange()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Slot")
            {
                foreach (Transform grandChild in child)
                {
                    if (!grandChild.gameObject.activeSelf)
                    {
                        Destroy(grandChild.gameObject);
                    }
                }
            }
        }
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<FishEat>().enabled = true;
        GetComponent<PlayerXRay>().enabled = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Destroy(this);

        
    }


}
