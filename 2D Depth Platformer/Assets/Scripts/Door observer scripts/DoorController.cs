using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DoorEvents.current.onDoorTriggerEnter += OnDoorOpen;
    }

    public void OnDoorOpen()
    {
        //GameObject.Find("door1").GetComponent<SpriteRenderer>().enabled = false;
        
        GameObject.Find("door1").SetActive(false);
        OnDisable();

    }
    public void OnDisable()
    {
        DoorEvents.current.onDoorTriggerEnter -= OnDoorOpen;
    }
}
