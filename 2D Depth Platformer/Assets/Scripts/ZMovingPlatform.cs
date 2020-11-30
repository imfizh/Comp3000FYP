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
        if (nextPos == ePos.position)
        {
            GameObject go = this.gameObject;
            LayerManager other = (LayerManager)go.GetComponent(typeof(LayerManager));
            other.BackLayer();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (nextPos == sPos.position)
        {
            GameObject go = this.gameObject;
            LayerManager other = (LayerManager)go.GetComponent(typeof(LayerManager));
            other.MainLayer();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        // Code for if using orthographic camera to change size of platform, gives it a shrink effect
        //if (nextPos == ePos.position)
        //{
        //    Vector3 lTemp = this.transform.localScale;
        //    lTemp.x = lTemp.x / 2;
        //    lTemp.y = lTemp.y / 2;
        //    this.transform.localScale = lTemp;
        //}
        //if (nextPos == sPos.position)
        //{
        //    Vector3 lTemp = this.transform.localScale;
        //    lTemp.x = lTemp.x * 2;
        //    lTemp.y = lTemp.y * 2;
        //    this.transform.localScale = lTemp;
        //}
    }
}
