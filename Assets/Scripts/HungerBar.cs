using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class HungerBar : MonoBehaviour
{
    public MonoBehaviour scriptToDeactivate;
    public GameObject objectToDelete;
    public GameObject objectToMove; // Add this public variable
    public Slider slider;
    public float maxHunger = 100f;
    public float initialHungerDecreaseRate = 2f;
    public float hungerRateIncreasePerSecond = 0.1f;
    private float currentHunger;
    public Color greenColor = Color.green;
    public Color yellowColor = Color.yellow;
    public Color redColor = Color.red;
    public Color vignetteFixedColor = Color.black;
    public TextMeshProUGUI plasticText;
    public TextMeshProUGUI plasticTextEnd;
    private int plasticCount = 0;
    public Collider collectionCollider;
    public PostProcessProfile postProcessingProfile;
    private Vignette vignette;
    public float startVignetteIntensity = 0.55f;
    public float endVignetteIntensity = 1.0f;
    public GameObject enableObject;
    public GameObject enableObjectFishingRod;

    public Transform waypoint1;
    public Transform waypoint2;
    private Transform selectedWaypoint;
    private bool spacebarEnabled = true;

    private float timeSinceLastRateIncrease = 0f;

    void Start()
    {
        currentHunger = maxHunger;
        UpdateHungerBar();
        vignette = postProcessingProfile.GetSetting<Vignette>();
        selectedWaypoint = ChooseClosestWaypoint();
    }

    void Update()
    {
        currentHunger -= (initialHungerDecreaseRate + hungerRateIncreasePerSecond * timeSinceLastRateIncrease) * Time.deltaTime;
        timeSinceLastRateIncrease += Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
        UpdateHungerBar();
        UpdateVignette();
        SetFixedVignetteColor();

        if (currentHunger <= 0f)
        {
            EnableGameObject();

            // Destroy the objectToDelete when hunger reaches 0
            if (objectToDelete != null)
            {
                Destroy(objectToDelete);
            }

            // Disable the specified script when hunger reaches 0
            if (scriptToDeactivate != null)
            {
                scriptToDeactivate.enabled = false;
            }

            // Move objectToMove to the selected waypoint when hunger reaches 0
            if (objectToMove != null)
            {
                MoveObjectToWaypoint(objectToMove);
            }

            // Disable the spacebar input
            spacebarEnabled = false;
        }

        if (spacebarEnabled && Input.GetKeyDown(KeyCode.Space))
        {
            TryCollectObjects();
        }

        if (selectedWaypoint == null || Vector3.Distance(transform.position, selectedWaypoint.position) < 1.0f)
        {
            selectedWaypoint = ChooseClosestWaypoint();
        }
    }

    void UpdateHungerBar()
    {
        slider.value = currentHunger / maxHunger;
        if (currentHunger >= 75f)
        {
            slider.fillRect.GetComponent<Image>().color = Color.Lerp(greenColor, yellowColor, (currentHunger - 75f) / 25f);
        }
        else if (currentHunger >= 25f)
        {
            slider.fillRect.GetComponent<Image>().color = Color.Lerp(yellowColor, redColor, (25f - currentHunger) / 50f);
        }
        else
        {
            slider.fillRect.GetComponent<Image>().color = redColor;
        }
    }

    void UpdateVignette()
    {
        float t = 1 - (currentHunger / maxHunger);
        float vignetteIntensity = Mathf.Lerp(startVignetteIntensity, endVignetteIntensity, t);
        vignette.intensity.value = vignetteIntensity;
    }

    void SetFixedVignetteColor()
    {
        vignette.color.value = vignetteFixedColor;
    }

    void EnableGameObject()
    {
        if (enableObject != null)
        {
            enableObject.SetActive(true);
        }

        if (enableObjectFishingRod != null)
        {
            enableObjectFishingRod.SetActive(true);
        }
    }

    void TryCollectObjects()
    {
        Collider[] colliders = Physics.OverlapBox(collectionCollider.bounds.center, collectionCollider.bounds.extents, Quaternion.identity);
        foreach (Collider col in colliders)
        {
            GameObject collectibleObject = col.gameObject;
            if (collectibleObject.CompareTag("Food"))
            {
                currentHunger += 10f;
                currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
                initialHungerDecreaseRate *= 0.5f;
                Destroy(collectibleObject);
            }
            else if (collectibleObject.CompareTag("Plastic"))
            {
                plasticCount += 5;
                currentHunger += 5f;
                currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
                if (plasticText != null)
                {
                    plasticText.text = plasticCount.ToString();
                }

                if (plasticTextEnd != null)
                {
                    plasticTextEnd.text = plasticCount.ToString();
                }

                Destroy(collectibleObject);
            }
        }
    }

    Transform ChooseClosestWaypoint()
    {
        if (waypoint1 != null && waypoint2 != null)
        {
            float distanceToWaypoint1 = Vector3.Distance(transform.position, waypoint1.position);
            float distanceToWaypoint2 = Vector3.Distance(transform.position, waypoint2.position);

            if (distanceToWaypoint1 < distanceToWaypoint2)
            {
                return waypoint1;
            }
            else
            {
                return waypoint2;
            }
        }
        else if (waypoint1 != null)
        {
            return waypoint1;
        }
        else if (waypoint2 != null)
        {
            return waypoint2;
        }

        return null;
    }

    void MoveObjectToWaypoint(GameObject objToMove)
    {
        if (selectedWaypoint != null)
        {
            // You can adjust the speed and method of movement as needed
            float moveSpeed = 3.0f;
            objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, selectedWaypoint.position, moveSpeed * Time.deltaTime);
        }
    }
}
