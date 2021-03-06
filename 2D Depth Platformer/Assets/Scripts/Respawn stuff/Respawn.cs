﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    //[SerializeField] private Transform respawn1 = null;
    //[SerializeField] private Transform respawn2 = null;
    [SerializeField] private Transform[] respawn = new Transform[4];
    int lastCP = 1;
    int currentCP = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastCP = currentCP;
        currentCP = FindObjectOfType<CheckpointManager>().currentCheckpoint;
        // code for the test respawns
        //if (collision.tag == "Player" & currentCP == 1)
        //{
        //    if (GameObject.Find("mc").layer ==14)
        //    {
        //        GameObject.Find("mc").layer = 10;
        //    }
        //    player.transform.position = respawn1.transform.position;
        //}
        //if (collision.tag == "Player" & currentCP == 2)
        //{
        //    if (GameObject.Find("mc").layer == 10)
        //    {
        //        GameObject.Find("mc").layer = 14;
        //    }
        //    player.transform.position = respawn2.transform.position;
        //}
        if (collision.tag == "Player" & currentCP == lastCP)
        {
            if (GameObject.Find("mc").layer != GameObject.Find((lastCP).ToString()).layer)
            {
                GameObject.Find("mc").layer = GameObject.Find((lastCP).ToString()).layer;
            }
            player.transform.position = respawn[lastCP].transform.position;
        }
        if (collision.tag == "Player" & currentCP != lastCP)
        {
            if (GameObject.Find("mc").layer != GameObject.Find((currentCP).ToString()).layer)
            {
                GameObject.Find("mc").layer = GameObject.Find((currentCP).ToString()).layer;
            }
            player.transform.position = respawn[currentCP].transform.position;
        }
    }
}
