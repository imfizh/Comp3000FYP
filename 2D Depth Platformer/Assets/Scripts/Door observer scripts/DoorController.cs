using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    void Start()
    {
        DoorEvents.current.onDoorTriggerEnter += OnDoorOpen;
    }

    public void OnDoorOpen(int id)
    {
        if (id == this.id)
        {
            this.gameObject.SetActive(false);
            OnDisable();
        }
    }
    public void OnDisable()
    {
        DoorEvents.current.onDoorTriggerEnter -= OnDoorOpen;
    }
}
