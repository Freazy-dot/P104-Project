using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
    private AudioSource aSource;
    public float startSoundDelay = 2.2f;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        Invoke(nameof(PlaySound), startSoundDelay);
    }

    private void PlaySound()
    {
        aSource.Play();
    }

}
