using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;
    public Transform model;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;


    // Start is called before the first frame update
    void Start()
    {

        tempDistance = distance;
    }

    // Update is called once per frame
   
    float tempDistance;
    Vector3 offset = new Vector3(0, 2, 0);
    private void FixedUpdate()
    {
        currentX += -Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);
     
        Vector3 Direction = new Vector3(0, 0, -tempDistance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);


        //camera map Collision

        Vector3 rayDirection = gameObject.transform.position- (lookAt.position);
       
        if (Physics.Raycast(lookAt.position, rayDirection, out RaycastHit hit))
        {
            Debug.Log(hit.collider.tag);
                if (hit.distance < distance)
                {
                    tempDistance = hit.distance;

                }
                else
                {
                    tempDistance = distance;
                }
            
           

        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(model.position + offset, gameObject.transform.position);
    }
}