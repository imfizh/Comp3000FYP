using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform sPos, ePos;
    public float speed;
    public Transform StartPos;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Platform")
        {
            MoveOnX();
        }
    }
    public void MoveOnX()
    {
            if (transform.position == sPos.position)
            {
                nextPos = ePos.position;
            }
            if (transform.position == ePos.position)
            {
                nextPos = sPos.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    
}
