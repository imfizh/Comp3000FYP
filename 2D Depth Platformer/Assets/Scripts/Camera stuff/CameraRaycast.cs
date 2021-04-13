using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Transform player;
    public Transform feet;
    public Transform head;
    private AlphaWalls currentTransparentWall;
    private bool isCurrent = false;
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 d1 = feet.transform.position - transform.position;
        Vector3 d2 = head.transform.position - transform.position;
        float length = Vector3.Distance(player.transform.position, transform.position);
        Debug.DrawRay(transform.position, direction.normalized * length, Color.red);

        //LayerMask mask = LayerMask.GetMask("Background");
        //RaycastHit2D currentHit = Physics2D.Raycast(transform.position, direction, length, mask);
        //RaycastHit2D currentHit = Physics2D.Raycast(transform.position, direction, length);
        RaycastHit currentHit;
        if (Physics.Raycast(transform.position, direction, out currentHit, length, LayerMask.GetMask("Background")) ||
             Physics.Raycast(transform.position, d1, out currentHit, length, LayerMask.GetMask("Background")) ||
              Physics.Raycast(transform.position, d2, out currentHit, length, LayerMask.GetMask("Background")))
        //if (currentHit.collider != null)
        {
            Logic(currentHit.transform);
            if (isCurrent==false)
            {
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
            
        }
        else
        {
            if (currentTransparentWall)
            {
                currentTransparentWall.Alpha(false);
            }
        }

    }

    public bool Logic(Transform current)
    {
        if (current.CompareTag("Main") && player.gameObject.layer == 10)
        {
            isCurrent = true;
        }
        else
        {
            isCurrent = false;
        }
        return isCurrent;
    }
}

