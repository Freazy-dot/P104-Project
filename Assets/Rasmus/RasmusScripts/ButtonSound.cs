using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip soundClip;
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // Add a listener to the button click event
        button.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        // Play the assigned sound clip
        audioSource.PlayOneShot(soundClip);
    }
}