using UnityEngine;

public class FlipHorizontal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    private void Start()
    {
        // Get the SpriteRenderer component attached to this game object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Check for 'A' key (left) input
        if (Input.GetKey("d"))
        {
            if (facingRight)
            {
                // Flip the object to the left
                Flip();
            }
        }
        // Check for 'D' key (right) input
        else if (Input.GetKey("a"))
        {
            if (!facingRight)
            {
                // Flip the object to the right
                Flip();
            }
        }
    }

    private void Flip()
    {
        // Flip the object horizontally
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}



