using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ResetY : MonoBehaviour
{
    GameObject player;
    Vector3 reset = new Vector3(0, 0, 0);
    private void Start()
    {
        player = GameObject.Find("mc");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        GameObject.Find("mc").layer = 14;
    }
}
