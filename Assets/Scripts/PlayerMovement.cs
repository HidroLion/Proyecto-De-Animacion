using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    CharacterController Controller;

    public float Speed;
    public Animator anim;
    public Transform Cam;
    public Transform hips;
  
    // Start is called before the first frame update
    void Start()
    {

        Controller = GetComponent<CharacterController>();
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        transform.rotation = Quaternion.Euler(0, Cam.transform.localRotation.eulerAngles.y, 0);
        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        
        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;



        Controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            anim.SetBool("Walking",true);
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraControl>().sensivity * Time.deltaTime);


            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
            
        }
        else
        {
            anim.SetBool("Walking", false);

        }

    }

}
