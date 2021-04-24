using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxDisplay : MonoBehaviour
{
    public BoxFlyweight box;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = box.artwork;
        this.GetComponent<Rigidbody2D>().mass = box.massStationary;
    }

    
}
