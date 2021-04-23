using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDashBetween : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    GameObject player;
    private bool inTrigger = false;
    public int layer = 0;
    private Animator dashAnim;
    public GameObject dashEffect;
    private GameObject[] playerSprites = new GameObject[7];
    private AudioSource dashSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mc");
        dashAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        playerSprites[0] = GameObject.Find("body");
        playerSprites[1] = GameObject.Find("head");
        playerSprites[2] = GameObject.Find("head1");
        playerSprites[3] = GameObject.Find("left arm");
        playerSprites[4] = GameObject.Find("right arm");
        playerSprites[5] = GameObject.Find("left leg");
        playerSprites[6] = GameObject.Find("right leg");
        dashSound = GameObject.Find("DashSound").GetComponent<AudioSource>();
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
            
            dashSound.Play();
            dashAnim.SetTrigger("Shake");
            if (end.layer == 12)
            {
                player.layer = 10;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "Player";
                }
            }
            else if (end.layer == 13)
            {
                player.layer = 14;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerBack";
                }
            }
            else if (end.layer == 15)
            {
                player.layer = 16;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerFront";
                }
            }
            layer = 1;
        }
        else if (inTrigger == true && Input.GetKeyDown(KeyCode.K) && layer == 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, start.transform.position.z);
            Instantiate(dashEffect, player.transform.position, Quaternion.identity);
            dashSound.Play();
            dashAnim.SetTrigger("Shake");
            if (start.layer == 12)
            {
                player.layer = 10;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "Player";
                }
            }
            else if (start.layer == 13)
            {
                player.layer = 14;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerBack";
                }
            }
            else if (start.layer == 15)
            {
                player.layer = 16;
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerFront";
                }
            }
            layer = 0;
        }
    }
}
