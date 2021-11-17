using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateA : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip flipSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!GameControlA.youWin && PlayerInteraction.ActivePuzzle())
        {
            transform.Rotate(0f, 0f, 90f);
            audioSource.PlayOneShot(flipSound);
        }
    }
}