using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Transform player;
    private AlphaWalls currentTransparentWall;
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        float length = Vector3.Distance(player.transform.position, transform.position);
        Debug.DrawRay(transform.position, direction.normalized * length, Color.red);

        LayerMask mask = LayerMask.GetMask("Background");
        RaycastHit2D currentHit = Physics2D.Raycast(transform.position, direction, length, mask);
        //RaycastHit2D currentHit = Physics2D.Raycast(transform.position, direction, length);
        if (currentHit.collider != null)
        {
            Debug.Log("You hit: " + currentHit.collider.gameObject.name);
            AlphaWalls AW = currentHit.transform.GetComponent<AlphaWalls>();
            if (AW)
            {
                if (currentTransparentWall && currentTransparentWall.gameObject != AW.gameObject)
                {
                    currentTransparentWall.Alpha(false);
                }
                AW.Alpha(true);
                currentTransparentWall = AW;
            }
        }
        else
        {
            if (currentTransparentWall)
            {
                currentTransparentWall.Alpha(false);
            }
        }

    }


}

