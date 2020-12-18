using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isDialogue=false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DiaglogueManager>().StartDialogue(dialogue);
        isDialogue = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerDialogue();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DiaglogueManager>().EndDialogue();
        isDialogue = false;
    }

    public void Update()
    {
        if (isDialogue == true && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<DiaglogueManager>().DisplayNextSentence();
        }
    }

}
