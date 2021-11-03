using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Puerta")]
    [SerializeField] GameObject doorKey;
    [SerializeField] GameObject door;

    [Header("Text")]
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
            Debug.Log("Player in Area");
            ShowText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactiveArea = false;

            VanishText();
        }
    }

    void ShowText()
    {
        for (int i = 0; i < 256; i++)
        {
            textMeshPro.color =
               new Vector4(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, Mathf.Lerp(0, 255, 5));
        }
    }

    void VanishText()
    {
        for (int i = 0; i < 256; i++)
        {
            textMeshPro.color =
               new Vector4(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, Mathf.Lerp(255, 0, 5));
        }
    }
}
