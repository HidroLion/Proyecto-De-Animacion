using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBeaviour : MonoBehaviour
{
    
    public float dogSpeed;
    public Animator anim;
    public Transform[] points;
    public Transform player;
    public bool Seguir=true;
    public  LavaMonsterBehaviour lm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, gameObject.transform.position) > 5 && Seguir == false)
        {


            Seguir = true;

        }
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
            if (Vector3.Distance(transform.position, lm.transform.position) < 10 && lm.dead==false)
            {
                dogSpeed = 2;
                anim.SetBool("Stealth", true);


            }
            else
            {
                dogSpeed = 3.5f;
                anim.SetBool("Stealth", false);

            }
            if (Vector3.Distance(gameObject.transform.position, points[current].position) < 2)
            {
                
                current++;
                Seguir = false;
                anim.SetBool("Walking", false);
            }
            else {  }

        }
        else
        {
            anim.SetBool("Walking", false);
        }
      

    }
}
