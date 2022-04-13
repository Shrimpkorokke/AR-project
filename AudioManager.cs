using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource theAudio;
    public AudioClip[] clip;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        theAudio.clip = clip[0];

        if (theAudio.isPlaying)
        {
            theAudio.Stop();
            theAudio.Play();
        }
        else
        {
            theAudio.Play();

        }
    }
}
