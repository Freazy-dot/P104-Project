using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerXRay : MonoBehaviour
{
    [SerializeField] private float timeScale = 0.25f;
    [SerializeField] private GameObject XRayGameObject;
    [SerializeField] private float imageZPos = -1;
    private FishEat fe;

    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Sprite> spritesLvl3;
    [SerializeField] List<Sprite> spritesLvl4;

    GameObject UIElement;
    [HideInInspector] public bool canXray;



    // Start is called before the first frame update
    void Start()
    {
        fe = gameObject.GetComponent<FishEat>();
        UIElement = XRayGameObject.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canXray)
        {
            Time.timeScale = 1f;
            XRayGameObject.SetActive(false);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);

            }
        }

        XRayGameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, imageZPos);

        //i hate rotations taken from https://discussions.unity.com/t/rotate-object-weapon-towards-mouse-cursor-2d/1172/5
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //source end

        //flip at 90 degrees;
        //if (angle > 90 || angle < -90)
        //{
        //    XRayGameObject.transform.GetChild(0).transform.localScale = new Vector3(-1, -1, 1);
        //}
        //else
        //{
        //    XRayGameObject.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        //}


        UIElement.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));

        #region images per scene

        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2") //xray images for levels 1 and two
        {
            if (fe.foodCounter >= fe.foodGoal * 0.75)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = sprites[3];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.5)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = sprites[2];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.25)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = sprites[1];
            }
            else //no food
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = sprites[0];
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
            {
            if (fe.foodCounter >= fe.foodGoal * 0.75)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl3[3];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.5)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl3[2];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.25)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl3[1];
            }
            else //no food
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl3[0];
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            if (fe.foodCounter >= fe.foodGoal * 0.75)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl4[3];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.5)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl4[2];
            }
            else if (fe.foodCounter >= fe.foodGoal * 0.25)
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl4[1];
            }
            else //no food
            {
                UIElement.GetComponent<UnityEngine.UI.Image>().sprite = spritesLvl4[0];
            }
        }

        #endregion

    }

    private void OnXRay (InputValue value)
    {
        if(!canXray) { return; }
        if (value.isPressed)
        {

            //Debug.Log("ispressed");
            Time.timeScale = timeScale;
            XRayGameObject.SetActive(true);

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }


        }
        else
        {
            //Debug.Log("notpressed");
            Time.timeScale = 1f;
            XRayGameObject.SetActive(false);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);

            }
        }

        

    }
}
