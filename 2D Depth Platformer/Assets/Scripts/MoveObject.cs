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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interact == true && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
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
                rb.mass = 2000;
                stopInteract = false;
            }
            
        }
    }

    public void Interaction()
    {
        uiObject.SetActive(false);
        rb.mass = 20;
        stopInteract = true;
    }
}
