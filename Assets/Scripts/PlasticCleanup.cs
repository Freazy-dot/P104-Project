using UnityEngine;

public class PlasticCleanup : MonoBehaviour
{
    public BoxCollider targetCollider; // Assign the target BoxCollider in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plastic"))
        {
            Destroy(other.gameObject);
        }
    }
}
