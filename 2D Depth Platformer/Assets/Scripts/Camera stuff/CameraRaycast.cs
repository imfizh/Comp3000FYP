using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Transform player;
    public Transform feet;
    public Transform head;
    private AlphaWalls currentTransparentWall;
    //private bool isCurrent = false;
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position; //raycast to the mid point of the player
        Vector3 d1 = feet.transform.position - transform.position; //raycast to the players feet
        Vector3 d2 = head.transform.position - transform.position; // raycast to the players head
        float length = Vector3.Distance(player.transform.position, transform.position);
        Debug.DrawRay(transform.position, direction.normalized * length, Color.red);
        RaycastHit currentHit;
        if (Physics.Raycast(transform.position, direction, out currentHit, length, LayerMask.GetMask("Background")) || //check if raycast hits 'background' layer
             Physics.Raycast(transform.position, d1, out currentHit, length, LayerMask.GetMask("Background")) ||
              Physics.Raycast(transform.position, d2, out currentHit, length, LayerMask.GetMask("Background")))
        {
           AlphaWalls AW = currentHit.transform.GetComponent<AlphaWalls>();  //gets alpha walls script on gameobject that raycast hit
           if (AW){
               if (currentTransparentWall && currentTransparentWall.gameObject != AW.gameObject){ //if a wall is transparent, and that walls gameobject is the
                //not same as the gameobject the raycast is hitting                                                                                    
                        currentTransparentWall.Alpha(false); // if player is no longer behind the current wall, sets the alpha to false
               }
               AW.Alpha(true); // passes true to Alpha function, makes gameobject transparent
               currentTransparentWall = AW; // the current AW is set as the currentTransparentWall
           }
        }
        else //if raycast no longer hits an object, makes the wall that was transparent no longer transparent
        {
            if (currentTransparentWall){
                currentTransparentWall.Alpha(false);
            }
        }
    }

    //public bool Logic(Transform current)  //doesn't do anything anymore
    //{
    //    if (current.CompareTag("Main") && player.gameObject.layer == 10)
    //    {
    //        isCurrent = true;
    //    }
    //    else
    //    {
    //        isCurrent = false;
    //    }
    //    return isCurrent;
    //}
}

