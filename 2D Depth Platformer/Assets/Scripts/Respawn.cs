using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameObject.Find("mc").layer ==14)
            {
                GameObject.Find("mc").layer = 10;
            }
            player.transform.position = respawn1.transform.position;
        }
    }
}
