using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public int lastCheckpoint = 1;

    public void ChangeCheckpoint(int checkpoint)
    {
        lastCheckpoint = checkpoint;
    }
}
