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

    public event Action onDoorTriggerEnter;
    public void DoorTriggerEnter()
    {
        if (onDoorTriggerEnter != null)
        {
            onDoorTriggerEnter();
        }
    }
}
