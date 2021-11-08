using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip audioPasos, audioMuerte, audioRopa;
    [SerializeField] AudioClip[] audioDaño;
    AudioSource playerAudioSource;
    bool playingSteps;

    [Header("Delay de Sonidos Random")]
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    [SerializeField] float SFXVolume;
    float randomDelay, timer;

    private void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playingSteps = false;
        SetRandomDelay();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= randomDelay)
        {
            playerAudioSource.PlayOneShot(audioRopa, SFXVolume);
            timer = 0;
            SetRandomDelay();
        }

        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) &&
            playingSteps == false)
        {
            PlaySteps();
            playingSteps = true;
        }
        else if ((!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) &&
            playingSteps == true)
        {
            StopSteps();
            playingSteps = false;
        }
    }

    void SetRandomDelay()
    {
        randomDelay = Random.Range(minDelay, maxDelay);
    }

    void PlaySteps()
    {
        playerAudioSource.clip = audioPasos;
        playerAudioSource.Play();
        playingSteps = true;
    }

    void StopSteps()
    {
        playerAudioSource.Stop();
        playingSteps = false;
    }
}
