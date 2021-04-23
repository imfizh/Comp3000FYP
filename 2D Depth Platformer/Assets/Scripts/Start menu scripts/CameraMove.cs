using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // private GameObject cam;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       // cam = GameObject.Find("Main camera");
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.position = new Vector3(cam.transform.position.x + 0.01f, cam.transform.position.y, cam.transform.position.z);
        this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
    }
}
