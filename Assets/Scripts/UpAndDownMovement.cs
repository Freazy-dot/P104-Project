using UnityEngine;
using System.Collections.Generic;

public class UpAndDownMovement : MonoBehaviour
{
    public float upAndDownSpeed = 2.0f;
    public float upAndDownDistance = 1.0f;
    public int upAndDownRepetitions = 3;
    public float fastUpSpeed = 5.0f;
    public float fastUpDistance = 10.0f;
    public GameObject targetObject;
    public List<GameObject> objectsToDisable;
    public List<GameObject> objectsToEnable;

    private Vector3 startPosition;
    private bool movingUp;
    private int repetitions;
    private bool isActive;

    private void Start()
    {
        startPosition = transform.position;
        movingUp = true;
        repetitions = 0;
        isActive = false;
    }

    private void Update()
    {
        if (targetObject != null && targetObject.activeInHierarchy)
        {
            ActivateScript();
        }

        if (isActive)
        {
            if (repetitions < upAndDownRepetitions)
            {
                if (movingUp)
                {
                    transform.Translate(Vector3.up * upAndDownSpeed * Time.deltaTime);
                    if (transform.position.y - startPosition.y >= upAndDownDistance)
                    {
                        movingUp = false;
                    }
                }
                else
                {
                    transform.Translate(Vector3.down * upAndDownSpeed * Time.deltaTime);
                    if (transform.position.y <= startPosition.y)
                    {
                        movingUp = true;
                        repetitions++;
                    }
                }
            }
            else
            {
                transform.Translate(Vector3.up * fastUpSpeed * Time.deltaTime);
                if (transform.position.y - startPosition.y >= fastUpDistance)
                {
                    repetitions = 0;
                    transform.position = startPosition;

                    // Disable specified objects
                    foreach (var obj in objectsToDisable)
                    {
                        obj.SetActive(false);
                    }

                    // Enable specified objects
                    foreach (var obj in objectsToEnable)
                    {
                        obj.SetActive(true);
                    }
                }
            }
        }
    }

    public void ActivateScript()
    {
        isActive = true;
    }
}
