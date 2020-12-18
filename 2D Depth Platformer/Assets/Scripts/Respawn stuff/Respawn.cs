using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform respawn1 = null;
    [SerializeField] private Transform respawn2 = null;
    int currentCP = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentCP = FindObjectOfType<CheckpointManager>().lastCheckpoint;
        if (collision.tag == "Player" & currentCP == 1)
        {
            if (GameObject.Find("mc").layer ==14)
            {
                GameObject.Find("mc").layer = 10;
            }
            player.transform.position = respawn1.transform.position;
        }
        if (collision.tag == "Player" & currentCP == 2)
        {
            if (GameObject.Find("mc").layer == 10)
            {
                GameObject.Find("mc").layer = 14;
            }
            player.transform.position = respawn2.transform.position;
        }
    }
}
