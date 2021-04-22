using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ResetY : MonoBehaviour
{
    GameObject player;
    Vector3 reset = new Vector3(0, 0, 0);
    private GameObject[] playerSprites = new GameObject[7];
    private void Start()
    {
        player = GameObject.Find("mc");
        playerSprites[0] = GameObject.Find("body");
        playerSprites[1] = GameObject.Find("head");
        playerSprites[2] = GameObject.Find("head1");
        playerSprites[3] = GameObject.Find("left arm");
        playerSprites[4] = GameObject.Find("right arm");
        playerSprites[5] = GameObject.Find("left leg");
        playerSprites[6] = GameObject.Find("right leg");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            GameObject.Find("mc").layer = 14;
            for (int n = 0; n < playerSprites.Length; n++)
            {
                SpriteRenderer rend;
                rend = playerSprites[n].GetComponent<SpriteRenderer>();
                rend.sortingLayerName = "PlayerBack";
            }
        }
        
    }
}
