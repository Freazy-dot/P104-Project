using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerXRay : MonoBehaviour
{
    [SerializeField] private float timeScale = 0.25f;
    [SerializeField] private GameObject XRayGameObject;
    [SerializeField] private float imageZPos = -1;
    private FishEat fe;

    [SerializeField] List<Sprite> sprites;


    
    // Start is called before the first frame update
    void Start()
    {
        fe = gameObject.GetComponent<FishEat>();

    }

    // Update is called once per frame
    void Update()
    {
        XRayGameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, imageZPos);

        //i hate rotations taken from https://discussions.unity.com/t/rotate-object-weapon-towards-mouse-cursor-2d/1172/5
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //source end

        //flip at 90 degrees;
        if (angle > 90 || angle < -90)
        {
            XRayGameObject.transform.GetChild(0).transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            XRayGameObject.transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        }


        XRayGameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));

        if (fe.foodCounter > fe.foodGoal / 2)
        {
            XRayGameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = sprites[1];
        }

    }

    private void OnXRay (InputValue value)
    {
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
