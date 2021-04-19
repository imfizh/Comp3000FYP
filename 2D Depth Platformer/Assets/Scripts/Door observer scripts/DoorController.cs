using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        DoorEvents.current.onDoorTriggerEnter += OnDoorOpen;
    }

    public void OnDoorOpen(int id)
    {
        //GameObject.Find("door1").GetComponent<SpriteRenderer>().enabled = false;
        if (id == this.id)
        {
            //GameObject.Find("door1").SetActive(false);
            this.gameObject.SetActive(false);
            OnDisable();
        }
    }
    public void OnDisable()
    {
        DoorEvents.current.onDoorTriggerEnter -= OnDoorOpen;
    }
}
