using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public GameObject uiObject;
    public Rigidbody2D rb;
    private bool interact = false;
    private bool stopInteract = false;
    AudioSource push;
    private GameObject player;
    private bool beingPushed;
    private bool stopped;
    private bool pressed = false;
    void Start()
    {
        push = this.GetComponent<AudioSource>();
        player = GameObject.Find("mc");
    }
    void Update()
    {
        if (interact == true && Input.GetKeyDown(KeyCode.E))
        {
            beingPushed = true;
            Interaction();
        }
        if (beingPushed == true && player.GetComponent<PlayerMovement>().moveInput != 0)
        {
            push.Play();
            beingPushed = false;
        }
        if (beingPushed == false && player.GetComponent<PlayerMovement>().moveInput == 0)
        {
            push.Stop();
            stopped = true;
        }
        if (beingPushed == false && interact == true && stopped == true && pressed == true)
        {
            beingPushed = true;
            stopped = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact = true;
            uiObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact = false;
            uiObject.SetActive(false);
            if(stopInteract == true)
            {
                rb.mass = this.GetComponent<BoxDisplay>().box.massStationary;
                stopInteract = false;
            }
            push.Stop();
        }
        beingPushed = false;
        pressed = false;
    }

    public void Interaction()
    {
        uiObject.SetActive(false);
        rb.mass = this.GetComponent<BoxDisplay>().box.massPush;
        pressed = true;
        stopInteract = true;
    }
}
