using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Puerta")]
    [SerializeField] GameObject door;
    [SerializeField] GameObject cameraObject;
    [SerializeField] Transform cameraPos;

    Transform cameraOldPosition;
    CameraControl cameraControl;
    DoorController doorController;

    static bool interactiveArea;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
        cameraControl = cameraObject.GetComponent<CameraControl>();
        
        interactiveArea = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactiveArea = true;
            Debug.Log("[HidroLion] Player in Area");
            cameraControl.sensivity = 0;
            cameraControl.enabled = false;

            cameraOldPosition = cameraObject.transform;
            cameraObject.transform.position = cameraPos.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactiveArea = false;
            cameraControl.sensivity = -200;
            cameraControl.enabled = true;

            cameraObject.transform.position = cameraOldPosition.position;
        }
    }
    
    public static bool ActivePuzzle()
    {
        return interactiveArea;
    }
}
