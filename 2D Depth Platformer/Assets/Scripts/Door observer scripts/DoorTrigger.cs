﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoorEvents.current.DoorTriggerEnter();
    }
}
