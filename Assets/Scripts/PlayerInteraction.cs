using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject doorKey;
    [SerializeField] GameObject door;
    [SerializeField] GameObject text;

    DoorController doorController;
    TextMeshPro textMeshPro;
    bool interactiveArea;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
        textMeshPro = text.GetComponent<TextMeshPro>();

        interactiveArea = false;
    }

    private void Update()
    {
        if (interactiveArea)
        {
            if (Input.GetKey(KeyCode.F))
            {
                //Metodo que Activa el Puzzle

                //TEST
                doorController.OpenDoor();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactiveArea = true;

            ShowText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            interactiveArea = false;
    }

    void ShowText()
    {
        for (int i = 0; i < 256; i++)
        {
             
        }
    }
}
