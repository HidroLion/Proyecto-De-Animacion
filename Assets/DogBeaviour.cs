using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBeaviour : MonoBehaviour
{
    
    public float dogSpeed;
    public Animator anim;
    public Transform[] points;
    public bool Seguir=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Seguir) { startFollowing(); }
          
        
    }
    int current = 0;
    void startFollowing()
    { 
        anim.SetBool("Walking", true);
        if (current < points.Length)
        {
            float step = dogSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(gameObject.transform.position, points[current].position, step);
            transform.LookAt(points[current].position);
            if (Vector3.Distance(gameObject.transform.position, points[current].position) < 2)
            {
                current++;

            }

        }
        else
        {
            anim.SetBool("Walking", false);
        }
      

    }
}
