using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    public Transform location;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "box")
        {
            collision.gameObject.transform.position = location.transform.position;
            collision.gameObject.transform.rotation = location.transform.rotation;
        }
    }
}
