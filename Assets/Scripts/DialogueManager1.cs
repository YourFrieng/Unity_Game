using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager1 : MonoBehaviour
{
    public Queue<string> sentences;//list of future replicas
    private Queue<bool> isPlayerSentences;

    public GameObject Player;
    private Controller controller;
    private Animator anim;
    public Dialogue dialogue;
    public GameObject dialogueBox;
    public Color playerColor;
    public Text dialogueText;
    bool n = true;//used to activate StartDialogue() function once
    public npcMovement npcMovement;
    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
        isPlayerSentences = new Queue<bool>();
        controller = Player.GetComponent<Controller>();
        anim = Player.GetComponent<Animator>();
        npcMovement = GetComponent<npcMovement>();
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
        controller.enabled = false;
        anim.enabled = false;
        npcMovement.moveSpeed = 0;
        dialogueBox.SetActive(true);
        foreach (string sentence in dialogue.sentences)//copy replicas from Dialogue to Queue 
        {
            sentences.Enqueue(sentence);
        }
        foreach (bool b in dialogue.isPlayerSentence)
        {
            isPlayerSentences.Enqueue(b);
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
        dialogueText.color = isPlayerSentences.Dequeue() ? playerColor : dialogue.npcTextColor;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)// do animation of text output
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
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
        npcMovement.moveSpeed = 20;
    }
}