using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{ 
    public Dialogue dialogue;
    public bool isDialogue = false;

    private bool jump = false;
    private bool jumpHigh = false;
    private bool movePlat = false;
    private bool movePlatZ = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DiaglogueManager>().StartDialogue(dialogue);
        isDialogue = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // TriggerDialogue();
        if (this.name == "Jumping tut" && jump == false)
        {
            TriggerDialogue();
        }
        else if (this.name == "Jumping higher tut" && jumpHigh == false)
        {
            TriggerDialogue();
        }
        else if (this.name == "Moving platform tut" && movePlat == false)
        {
            TriggerDialogue();
        }
        else if (this.name == "Moving platform z tut" && movePlatZ == false)
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DiaglogueManager>().EndDialogue();
        isDialogue = false;
        if (this.name == "Jumping tut")
        {
            jump = true;
        }
        else if (this.name == "Jumping higher tut")
        {
            jumpHigh = true;
        }
        else if (this.name == "Moving platform tut")
        {
            movePlat = true;
        }
        else if (this.name == "Moving platform z tut")
        {
            movePlatZ = true;
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
