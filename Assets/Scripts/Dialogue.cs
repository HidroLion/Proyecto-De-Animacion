using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public static Dialogue instance;
    public string[] sentences;
    bool DialogueActive;
    int currentSentence;
    
    public GameObject DialogueSquare;
   
    // Start is called before the first frame update
    void Start()
    {
  
        if (instance!= null)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;

        }
        currentSentence = 0;
        DialogueActive = false;
           sentences = new string[1];
        DialogueSquare.SetActive(false);

    }
    public void SetDialogue(string[] _sentences) {
        CameraControl.instance.isFighting = true;
        DialogueSquare.SetActive(true);
        DialogueActive = true;
        sentences = _sentences;
        SetDialogueText(sentences[currentSentence]);

    }
  
    public void SetDialogueText(string _text) {
        dialogueText.text = _text;
    }
   
    
    public void NextSentence() {

        
            if (currentSentence + 1 < sentences.Length)
            {
                currentSentence++;
                SetDialogueText(sentences[currentSentence]);
            }
            else
            {
                DialogueActive = false;
                currentSentence = 0;
                DialogueSquare.SetActive(false);
           
            CameraControl.instance.isFighting = false;
            if (DecisionMaking.instance.enemy != null) {
                DecisionMaking.instance.StartDecisionMaking();
              
            }    
            }
       

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NextSentence();

        }
        
    }
}
