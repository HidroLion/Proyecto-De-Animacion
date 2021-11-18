using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Puerta")]
    [SerializeField] GameObject door;

    DoorController doorController;

    static bool interactiveArea;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactiveArea = false;           
        }
    }
    
    public static bool ActivePuzzle()
    {
        return interactiveArea;
    }
}
