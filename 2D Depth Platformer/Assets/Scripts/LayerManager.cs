using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    // Script incharge of keeping track of what layer a platform/player is on 
    public int layer;
   
    public void MainLayer()
    {
        this.layer = 1;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void BackLayer()
    {
        this.layer = 0;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
