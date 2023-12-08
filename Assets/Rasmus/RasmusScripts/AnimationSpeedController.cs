using UnityEngine;

public class AnimationSpeedController : MonoBehaviour
{
    // Public variable to control animation speed multiplier
    public float animationSpeedMultiplier = 1.0f;

    // Reference to the Animator component
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Check if Animator component is found
        if (animator == null)
        {
            Debug.LogError("Animator component not found on GameObject.");
        }
    }

    void Update()
    {
        // Update the animation speed based on the multiplier
        animator.speed = animationSpeedMultiplier;
    }
}
