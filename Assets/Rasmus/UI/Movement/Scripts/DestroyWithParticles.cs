using UnityEngine;

public class DestroyWithParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionParticles;
    private ParticleSystem instantiatedParticles;

    private void OnDisable()
    {
        if (destructionParticles != null)
        {
            // Instantiate the particle system at the position of the object
            instantiatedParticles = Instantiate(destructionParticles, transform.position, Quaternion.identity);

            // Play the particle system once
            instantiatedParticles.Play();
        }
    }

    private void Update()
    {
        // Check if the instantiated particle system exists and is not playing
        if (instantiatedParticles != null && !instantiatedParticles.isPlaying)
        {
            // Destroy the particle system
            Destroy(instantiatedParticles.gameObject);
        }
    }
}