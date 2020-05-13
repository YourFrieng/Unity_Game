using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class varDialogueManager : MonoBehaviour
{
    public Queue<string> sentences;//list of future replicas
    public Queue<Color> Colors;
    public GameObject Player;
    private Controller controller;
    private Animator anim;
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public Color playerColor;
    public Text dialogueText;
    bool n = true;//used to activate StartDialogue() function once;

    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
        Colors = new Queue<Color>();
        controller = Player.GetComponent<Controller>();
        anim = Player.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)//conditions to start dialogue
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (n)
                {
                    StartDialogue();
                    n = false;
                }
                DisplayNextSentence();
            }
        }
    }
    public void StartDialogue()
    {
      //  controller.enabled = false;
      //  anim.enabled = false;
        dialogueBox.SetActive(true);
        foreach (string sentence in dialogue.sentences)//copy replicas from Dialogue to Queue 
        {
            sentences.Enqueue(sentence);
        }
        foreach (Color c in dialogue.colors)
        {
            Colors.Enqueue(c);
        }
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)//when there won't be any replica, start EndDialogue()
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.color = Colors.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)// do animation of text output
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        controller.enabled = true;
        anim.enabled = true;
    }
}
