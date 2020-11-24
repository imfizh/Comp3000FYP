using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaWalls : MonoBehaviour
{
    private Renderer rend;
    Color matColour;
    private bool transparent = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        matColour = rend.material.color;
    }

    public void Alpha(bool transparent)
    {
        if (this.transparent == transparent) return;

        this.transparent = transparent;

        if (transparent)
        {
            matColour.a = 0.5f;
        }
        else
        {
            matColour.a = 1.0f;
        }
        rend.material.color = matColour;
    }
}
