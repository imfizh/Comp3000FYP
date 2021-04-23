using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RespawnEvents : MonoBehaviour
{
    public static RespawnEvents current;

    public void Awake()
    {
        current = this;
    }

    public event Action<int> onRespawnEnter;
    public void RespawnEnter(int id)
    {
        if (onRespawnEnter != null)
        {
            onRespawnEnter(id);
        }
    }
}
