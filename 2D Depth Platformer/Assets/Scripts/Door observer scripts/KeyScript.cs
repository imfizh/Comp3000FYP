using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        door.GetComponent<DoorController>().id = 1;
        //GameObject.Find("door1").GetComponent<DoorController>().id = 1;
    }
}
