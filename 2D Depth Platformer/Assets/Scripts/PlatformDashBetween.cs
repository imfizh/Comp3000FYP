using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDashBetween : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    GameObject player;
    private bool inTrigger = false;
    private int layer = 0;
    private Animator dashAnim;
    public GameObject dashEffect;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mc");
        dashAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = false;
        }
    }
    public void Switch()
    {
        if (inTrigger == true && Input.GetKeyDown(KeyCode.K) && layer == 0)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, end.transform.position.z);
            Instantiate(dashEffect, player.transform.position, Quaternion.identity);
            dashAnim.SetTrigger("Shake");
            if (end.layer == 12)
            {
                player.layer = 10;
            }
            else if (end.layer == 13)
            {
                player.layer = 14;
            }
            else if (end.layer == 15)
            {
                player.layer = 16;
            }
            layer = 1;
        }
        else if (inTrigger == true && Input.GetKeyDown(KeyCode.K) && layer == 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, start.transform.position.z);
            Instantiate(dashEffect, player.transform.position, Quaternion.identity);
            dashAnim.SetTrigger("Shake");
            if (start.layer == 12)
            {
                player.layer = 10;
            }
            else if (start.layer == 13)
            {
                player.layer = 14;
            }
            else if (start.layer == 15)
            {
                player.layer = 16;
            }
            layer = 0;
        }
    }
}
