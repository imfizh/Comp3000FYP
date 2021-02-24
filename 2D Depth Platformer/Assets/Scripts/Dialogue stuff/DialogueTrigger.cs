using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isDialogue=false;

    public GameObject uiObject;
    private bool interact = false;
    public void TriggerDialogue()
    {
        FindObjectOfType<DiaglogueManager>().StartDialogue(dialogue);
        isDialogue = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TriggerDialogue();
        if (collision.CompareTag("Player"))
        {
            interact = true;
            uiObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        uiObject.SetActive(false);
        interact = false;
        FindObjectOfType<DiaglogueManager>().EndDialogue();
        isDialogue = false;
    }

    public void Update()
    {
        if (interact == true && Input.GetKeyDown(KeyCode.E))
        {
            uiObject.SetActive(false);
            Interact();
        }
        if (isDialogue == true && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<DiaglogueManager>().DisplayNextSentence();
        }
    }
    public void Interact()
    {
        TriggerDialogue();
    }

}
