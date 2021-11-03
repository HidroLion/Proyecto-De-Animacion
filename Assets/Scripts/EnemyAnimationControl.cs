using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public Animator anim;

  
   
    public void RecieveDamage() {
        anim.SetTrigger("DamageTaken");
    }
    public void Die() {
        anim.SetTrigger("Dead");
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    void Update()
    {
        
    }
}
