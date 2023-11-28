using UnityEngine;

public class DestroyWithParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionParticles;
    [SerializeField] private AudioClip destructionSound;
    private ParticleSystem instantiatedParticles;
    private AudioSource audioSource;

    private void OnDisable()
    {
        if (destructionParticles != null)
        {
            // Instantiate the particle system at the position of the object
            instantiatedParticles = Instantiate(destructionParticles, transform.position, Quaternion.identity);

            // Play the particle system once
            instantiatedParticles.Play();
        }

        if (destructionSound != null)
        {
            // Create an AudioSource component if not already present
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Play the destruction sound
            audioSource.PlayOneShot(destructionSound);
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