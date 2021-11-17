using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateA : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] AudioSource flipSound;
    private void OnMouseDown()
    {
        if (!GameControlA.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
            // flipSound.Play();
        }

    }
}