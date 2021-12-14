using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioNine : MonoBehaviour
{
    [SerializeField]
    AudioClip ribbon, hit, laughter;

    AudioSource audioSource;

    public static AudioNine instance;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        instance = this;
    }

    public void PlayRibbon ()
    {
        audioSource.clip = ribbon;
        audioSource.Play();
    }

    public void PlayHit()
    {
        audioSource.clip = hit;
        audioSource.Play();
    }

    public void PlayLaughter()
    {
        audioSource.clip = laughter;
        audioSource.Play();
    }

}
