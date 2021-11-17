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
    void Start()
    {
        if (instance != null) { Destroy(this); } else { instance = this; }
        
    }
    public void StartDecisionMaking()
    {

        talkOption.GetComponentInChildren<TextMeshProUGUI>().text =enemy.talkOption;
        panel.SetActive(true);
      
    }
    public void SFinishDecisionMaking()
    {
        panel.SetActive(false);

    }
    public void Fight() {
        playerAnim.SetTrigger("Attack");
        enemy.RecieveDamage();
        runOption.SetActive(false);
        panel.SetActive(false);

    }
    public void Run()
    {
        playerAnim.SetTrigger("Run");
        runOption.SetActive(false);
        panel.SetActive(false);

    }
    public void Talk()
    {
        playerAnim.SetTrigger("Talk");
        runOption.SetActive(false);
        string[] s = new string[1];
        s[0] = enemy.talkResponse;
        Dialogue.instance.SetDialogue(s);
        panel.SetActive(false);
        enemy = null;
    
    }

    void Update()
    {
        
    }
}
