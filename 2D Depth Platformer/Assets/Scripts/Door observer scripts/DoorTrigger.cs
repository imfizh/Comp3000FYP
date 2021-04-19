using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int id;
    public Dialogue dialogue;
    public bool isDialogue = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoorEvents.current.DoorTriggerEnter(id);
        if (this.GetComponentInChildren<DoorController>() != null)
        {
            if (this.GetComponentInChildren<DoorController>().id != id)
            {
                TriggerDialogue();
            }
        }
        
        //TriggerDialogue();
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DiaglogueManager>().EndDialogue();
        isDialogue = false;
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DiaglogueManager>().StartDialogue(dialogue);
        isDialogue = true;
    }
    public void Update()
    {
        if (isDialogue == true && Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<DiaglogueManager>().DisplayNextSentence();
        }
    }
}
