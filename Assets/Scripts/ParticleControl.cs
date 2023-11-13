using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
public class ParticleControl : MonoBehaviour
{
    public ParticleSystem particles;

    private bool isEmitting = false;

    private void Start()
    {
        particles.Stop(); // Stop the particle emission when the scene starts
    }

    private void Update()
    {
        bool shouldEmit = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        var emission = particles.emission;

        if (shouldEmit)
        {
            if (!isEmitting)
            {
                particles.Play(); // Start particle emission when any of the keys are pressed
                isEmitting = true;
            }
            emission.enabled = true; // Enable the emission module to keep particles already spawned
        }
        else
        {
            if (isEmitting)
            {
                isEmitting = false;
            }
            emission.enabled = false; // Disable the emission module to stop spawning new particles
        }
    }
}




