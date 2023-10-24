using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip gameIntro;
    public AudioClip normalStateMusic;

    private bool hasStartedNormalStateMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = gameIntro;

        audioSource.Play();

        Invoke("PlayNormalStateMusic", gameIntro.length);
    }

    void PlayNormalStateMusic()
    {
        audioSource.clip = normalStateMusic;

        audioSource.loop = true;

        if (!hasStartedNormalStateMusic)
        {
            audioSource.Play();
            hasStartedNormalStateMusic = true;
        }
    }
}
