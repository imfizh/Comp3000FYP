using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerScript : MonoBehaviour
{
    float time = 1f;
    [SerializeField] private GameObject bridgeFull;
    [SerializeField] private GameObject bridgeBroke;
    [SerializeField] private GameObject piece1;
    [SerializeField] private GameObject piece2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject.Find("mc").GetComponent<PlayerMovement>().speed = 0;
        this.GetComponent<AudioSource>().Play();
        StartCoroutine(Load(1));
    }
    IEnumerator Load(int index)
    {
        yield return new WaitForSeconds(time);
        bridgeBroke.SetActive(true);
        bridgeFull.SetActive(false);
        piece1.SetActive(true);
        piece2.SetActive(true);
    }
}
