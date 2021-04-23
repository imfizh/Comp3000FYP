using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{ 
    public Dialogue dialogue;
    public bool isDialogue = false;

    private bool tutTriggered;

    public void TriggerDialogue()
    {
        FindObjectOfType<DiaglogueManager>().StartDialogue(dialogue);
        isDialogue = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tutTriggered == false)
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DiaglogueManager>().EndDialogue();
        isDialogue = false;
        if (collision.tag == "Player" && tutTriggered == false)
        {
            this.tutTriggered = true;
        }
        
    }

    public void Update()
    {
        if (isDialogue == true && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<DiaglogueManager>().DisplayNextSentence();
        }
    }
}
