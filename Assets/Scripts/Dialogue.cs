using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    bool DialogueActive;
    int currentSentence;
    public GameObject DialogueSquare;
    // Start is called before the first frame update
    void Start()
    {
        currentSentence = 0;
        DialogueActive = false;
           sentences = new string[1];
        DialogueSquare.SetActive(false);

    }
    public void SetDialogue(string[] _sentences) {
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
        else {
            DialogueActive = false;
            currentSentence = 0;
            DialogueSquare.SetActive(false);
        }
      

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NextSentence();

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            string[] s = new string[3];
            s[0] = "aaaaaaaaaaa";
            s[1] = "bbbbbbbbb";
            s[2] = "cccccccccccc";
            SetDialogue(s);
        }
    }
}
