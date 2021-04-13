using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0,1.5f,-28);
    public float followSpeed = 10f;
    public float xMin = 0f;
    Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPos = player.position + offset;
        //Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 clampedPos = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }


}
