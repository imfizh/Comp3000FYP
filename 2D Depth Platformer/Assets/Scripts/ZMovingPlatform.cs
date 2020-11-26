using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMovingPlatform : MonoBehaviour
{
    public Transform sPos, ePos;
    public Transform StartPos;
    Vector3 nextPos;
    float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (transform.position == sPos.position)
        {
            nextPos = ePos.position;
        }
        if (transform.position == ePos.position)
        {
            nextPos = sPos.position;
        }
        if (elapsed >= 2f)
        {
            elapsed = elapsed % 2f;
            Move();
        }
    }
    void Move()
    {
        transform.position = nextPos;
        if(nextPos == ePos.position)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = lTemp.x / 2;
            lTemp.y = lTemp.y / 2;
            transform.localScale = lTemp;
        }
        if (nextPos == sPos.position)
        {
            Vector3 lTemp = transform.localScale;
            lTemp.x = lTemp.x * 2;
            lTemp.y = lTemp.y * 2;
            transform.localScale = lTemp;
        }
    }
}
