using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    // Script incharge of keeping track of what layer a platform/player is on 
    public int layer;
    public int currentLayer;
   
    public void MainLayer()
    {
        this.layer = 1;
    }
    public void BackLayer()
    {
        this.layer = 0;
    }

    public int GetLayer(int cl)
    {
        cl = this.layer;
        return cl;
    }

}
