using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;

public class Change : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        levelLoader load = FindObjectOfType<levelLoader>();
        //levelLoader load = new levelLoader();
        load.LoadLevel();
    }
}
