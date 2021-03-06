﻿using System;
using UnityEngine;

public class ZMovingPlatform : MonoBehaviour
{
    public GameObject sPos, ePos;
    public Transform StartPos;
    Vector3 nextPos;
    float elapsed = 0f;
    bool onPlatform = false;
    int nextPosLayer;
    public Sprite sSprite;
    public Sprite eSprite;
    AudioSource zAudio;
    private GameObject[] playerSprites = new GameObject[7];
    // Start is called before the first frame update
    void Start()
    {
        nextPos = StartPos.position;
        zAudio = this.GetComponentInChildren<AudioSource>();
        playerSprites[0] = GameObject.Find("body");
        playerSprites[1] = GameObject.Find("head");
        playerSprites[2] = GameObject.Find("head1");
        playerSprites[3] = GameObject.Find("left arm");
        playerSprites[4] = GameObject.Find("right arm");
        playerSprites[5] = GameObject.Find("left leg");
        playerSprites[6] = GameObject.Find("right leg");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    elapsed += Time.deltaTime;
    //    if (transform.position == sPos.position)
    //    {
    //        nextPos = ePos.position;
    //    }
    //    if (transform.position == ePos.position)
    //    {
    //        nextPos = sPos.position;
    //    }
    //    if (elapsed >= 2f)
    //    {
    //        elapsed = elapsed % 2f;
    //        Move();
    //    }
    //}
    //void Move()
    //{
    //    zAudio.Play();
    //    transform.position = nextPos;
    //    if (nextPos == ePos.position)
    //    {
    //        GameObject go = this.gameObject;
    //        LayerManager other = (LayerManager)go.GetComponent(typeof(LayerManager));
    //        other.BackLayer();
    //        if (onPlatform==true)
    //        {
    //            GameObject.Find("mc").layer = 14;
    //            SpriteRenderer rend;
    //            rend = GameObject.Find("mc").GetComponent<SpriteRenderer>();
    //            rend.sortingLayerName = "PlayerBack";
    //        }
    //        this.gameObject.layer=13;
    //        this.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    //    }

    //    if (nextPos == sPos.position)
    //    {
    //        GameObject go = this.gameObject;
    //        LayerManager other = (LayerManager)go.GetComponent(typeof(LayerManager));
    //        other.MainLayer();
    //        if (onPlatform == true)
    //        {
    //            GameObject.Find("mc").layer = 10;
    //            SpriteRenderer rend;
    //            rend = GameObject.Find("mc").GetComponent<SpriteRenderer>();
    //            rend.sortingLayerName = "Player";
    //        }
    //        this.gameObject.layer =12;
    //        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    //    }
    //}
    void Update()
    {
        elapsed += Time.deltaTime;
        if (transform.position == ePos.transform.position)
        {
            nextPos = sPos.transform.position;
            nextPosLayer = sPos.layer;
        }
        if (transform.position == sPos.transform.position)
        {
            nextPos = ePos.transform.position;
            nextPosLayer = ePos.layer;
        }
        if (elapsed >= 2f)
        {
            elapsed = elapsed % 2f;
            Move();
        }
    }
    void Move()
    {
        zAudio.Play();
            transform.position = nextPos;
            GameObject go = this.gameObject;
            LayerManager other = (LayerManager)go.GetComponent(typeof(LayerManager));

        if (nextPosLayer == ePos.layer)
        {
            if (eSprite != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = eSprite;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            
        }
        else if (nextPosLayer == sPos.layer)
        {
            if (sSprite != null)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = sSprite;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }


        if (nextPosLayer == 15) {
            this.gameObject.layer = 15;
            other.FrontLayer();
            if (onPlatform == true)
            {
                //SpriteRenderer rend;
                //rend = GameObject.Find("mc").GetComponent<SpriteRenderer>();
                //rend.sortingLayerName = "PlayerFront";
                for (int n = 0;n<playerSprites.Length;n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerFront";
                }
                GameObject.Find("mc").layer = 16;
            }
            }
            else if (nextPosLayer == 13) {
            this.gameObject.layer = 13;
            other.BackLayer();
            if (onPlatform == true)
            {
                //SpriteRenderer rend;
                //rend = GameObject.Find("mc").GetComponent<SpriteRenderer>();
                //rend.sortingLayerName = "PlayerBack";
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "PlayerBack";
                }
                GameObject.Find("mc").layer = 14;
            }
        }
            else if (nextPosLayer == 12) {
            this.gameObject.layer = 12;
            other.MainLayer();
            if (onPlatform == true)
            {
                //SpriteRenderer rend;
                //rend = GameObject.Find("mc").GetComponent<SpriteRenderer>();
                //rend.sortingLayerName = "Player";
                for (int n = 0; n < playerSprites.Length; n++)
                {
                    SpriteRenderer rend;
                    rend = playerSprites[n].GetComponent<SpriteRenderer>();
                    rend.sortingLayerName = "Player";
                }
                GameObject.Find("mc").layer = 10;
            }
        }
            

    }
    void ChangePlayerLayerBack()
    {
        GameObject.Find("mc").layer = 14;
    }
    void ChangePlayerLayerMain()
    {
        GameObject.Find("mc").layer = 10;
    }
    void ChangePlayerLayerFront()
    {
        GameObject.Find("mc").layer = 16;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onPlatform = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onPlatform = false;
    }

    
}
