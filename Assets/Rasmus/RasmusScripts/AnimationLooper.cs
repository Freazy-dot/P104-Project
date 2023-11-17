using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator; // Drag and drop your Animator component here

    void Start()
    {
        // If animator is not assigned in the Inspector, try to get it from the GameObject
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found! Make sure it's assigned or attached to the GameObject.");
        }
    }

    void Update()
    {
        // Get all animation clips from the Animator Controller
        AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;

        // Loop through each animation clip
        foreach (var clip in animationClips)
        {
            // Check if the current animation is not playing
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(clip.name))
            {
                // Trigger the animation to start playing again
                animator.SetTrigger("StartAnimation");
            }
        }
    }
}
