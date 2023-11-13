using UnityEngine;

public class ActivateUIOnCollision : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to activate
    private Collider col; // Reference to the collider

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object you want to trigger the activation
        {
            uiElement.SetActive(true); // Activate the UI element
            Destroy(col.gameObject); // Delete the collider (including its game object)
        }
    }
}
