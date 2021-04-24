using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box",menuName = "Box")]
public class BoxFlyweight : ScriptableObject
{
    public Sprite artwork;
    public float massStationary;
    public float massPush;
}
