using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaWalls : MonoBehaviour
{
    private Renderer rend;
    Color matColour;
    private bool transparent = false;
    //These variables and the commented out code is for when not using the lightweight render pipeline

    // Start is called before the first frame update
    void Start()
    {
        //rend = gameObject.GetComponent<SpriteRenderer>();
        //matColour = rend.material.color;
    }

    public void Alpha(bool transparent)
    {
        if (this.transparent == transparent) return;

        this.transparent = transparent;

        if (transparent)
        {
            //matColour.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
        }
        else
        {
            //matColour.a = 1.0f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        //rend.material.color = matColour;
    }
}
