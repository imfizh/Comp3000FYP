using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;

    public void Awake()
    {
        current = this;
    }

    public event Action<int> onDoorTriggerEnter;
    public void DoorTriggerEnter(int id)
    {
        if (onDoorTriggerEnter != null)
        {
            onDoorTriggerEnter(id);
        }
    }
}
