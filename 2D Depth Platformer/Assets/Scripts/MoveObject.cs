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
    private bool test;
    private bool stopped;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
       // push = GameObject.Find("box").GetComponent<AudioSource>();
        push = this.GetComponent<AudioSource>();
        player = GameObject.Find("mc");
    }

    // Update is called once per frame
    void Update()
    {
        if (interact == true && Input.GetKeyDown(KeyCode.E))
        {
            test = true;
            Interaction();
        }
        if (test == true && player.GetComponent<PlayerMovement>().moveInput != 0)
        {
            push.Play();
            test = false;
        }
        if (test == false && player.GetComponent<PlayerMovement>().moveInput == 0)
        {
            push.Stop();
            stopped = true;
        }
        if (test == false && interact == true && stopped == true && pressed == true)
        {
            test = true;
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
                //rb.mass = 2000;
                stopInteract = false;
            }
            push.Stop();
        }
        test = false;
        pressed = false;
    }

    public void Interaction()
    {
        uiObject.SetActive(false);
        rb.mass = this.GetComponent<BoxDisplay>().box.massPush;
        //rb.mass = 20;
        pressed = true;
        stopInteract = true;
    }
}
