using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            id = GameObject.Find("Death & respawn").GetComponent<CheckpointManager>().currentCheckpoint;
            RespawnEvents.current.RespawnEnter(id);
        }
        
    }
}
