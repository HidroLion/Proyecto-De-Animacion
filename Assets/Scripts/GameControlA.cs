using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlA : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField] GameObject door;

    DoorController doorController;
    public static bool youWin;
    
    bool gano;

    void Awake()
    {
        doorController = door.GetComponent<DoorController>();
        gano = false;
        youWin = false;
    }
    void Update()
    {
        if ((pictures[0].rotation.z == 0 || pictures[0].rotation.z == 360) && (pictures[1].rotation.z == 0 || pictures[1].rotation.z == 360) && (pictures[2].rotation.z == 0 || pictures[2].rotation.z == 360) && (pictures[3].rotation.z == 0 || pictures[3].rotation.z == 360))
        {
            Debug.Log("Gano");
            youWin = true;
         
            if (gano == false)
            {            
                gano = true;
                doorController.OpenDoor();
            }
        }
    }

    public bool IsWin()
    {
        return youWin;
    }
}
