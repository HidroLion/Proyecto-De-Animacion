using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    [SerializeField] float openSpeed;

    public bool doorOpening;

    private void Start()
    {
        doorOpening = false;
    }

    public void OpenDoor()
    {
        doorOpening = true;
    }

    private void Update()
    {
        if (doorOpening)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, targetPosition.position, openSpeed);

            if (transform.position == targetPosition.position)
                doorOpening = false;
        }
    }
}
