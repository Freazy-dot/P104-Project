using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMeText : MonoBehaviour
{

    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Camera == null)
        {
            this.transform.LookAt(Camera.main.transform.position);
        }
        else
        {
            this.transform.LookAt(Camera.transform.position);
        }

    }
}
