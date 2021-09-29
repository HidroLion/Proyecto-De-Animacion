using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlA : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;


   
    public static bool youWin;
    
    bool gano;

    void Awake()
    {
        
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
               
            }
        }
    }
    public bool IsWin()
    {
        return youWin;
    }
}
