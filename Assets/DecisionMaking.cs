using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DecisionMaking : MonoBehaviour
{
    public GameObject panel,runOption,talkOption;
    GameObject[] options;
    public Animator playerAnim;
    public EnemyAnimationControl enemy;
    
    public static DecisionMaking instance;
    public PlayerMovement pm;
    void Start()
    {
        if (instance != null) { Destroy(this); } else { instance = this; }
        
    }
    public void StartDecisionMaking()
    {
        pm.enabled = false;
        
        talkOption.GetComponentInChildren<TextMeshProUGUI>().text =enemy.talkOption;
        panel.SetActive(true);
      
    }
    public void SFinishDecisionMaking()
    {
        panel.SetActive(false);
        pm.enabled = true;
    }
    public void Fight() {
        if (enemy.GetComponent<LavaMonsterBehaviour>() != null)
        {
           
            enemy.GetComponent<LavaMonsterBehaviour>().dead = true;
            pm.enabled = true;
            playerAnim.SetTrigger("Attack");
            enemy.RecieveDamage();
            runOption.SetActive(false);
            panel.SetActive(false);
            CameraControl.instance.currentFight = 1;
        }
        else
        {
            pm.enabled = true;
            playerAnim.SetTrigger("Attack");
            playerAnim.SetInteger("AttackCombo", 1);
            enemy.RecieveDamage();
            runOption.SetActive(false);
            panel.SetActive(false);

        }
      

    }
    public void Run()
    {
        pm.enabled = true;
        playerAnim.SetTrigger("Run");
        runOption.SetActive(false);
        panel.SetActive(false);
        CameraControl.instance.currentFight = 1;
        
    }
    public void Talk()
    {
        pm.enabled = true;
        playerAnim.SetTrigger("Talk");
        runOption.SetActive(false);
        string[] s = new string[1];
        s[0] = enemy.talkResponse;
        Dialogue.instance.SetDialogue(s);
        panel.SetActive(false);
        enemy.Talk();
        enemy = null;
        StartCoroutine(wait());
    }

   public IEnumerator wait()
    {

        yield return new WaitForSeconds(5);
        CameraControl.instance.currentFight = 1;
    }
    void Update()
    {
        
    }
}
