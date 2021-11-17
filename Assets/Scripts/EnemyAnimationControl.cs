using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public Animator anim;
    public Collider fightTrigger;
    public string[] dialogueLines;
    public string talkOption;
    public string talkResponse;
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
    public void StartDialogue(string[] _lines) {
        Dialogue.instance.SetDialogue(_lines);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            StartDialogue(dialogueLines);
            fightTrigger.enabled = false;
           
            other.transform.parent.GetComponentInChildren<DecisionMaking>().enemy=this;
        }
    }
    void Update()
    {
        
    }
}
