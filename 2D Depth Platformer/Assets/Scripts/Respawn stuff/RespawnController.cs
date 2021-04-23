using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public int id;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        RespawnEvents.current.onRespawnEnter += OnRespawn;
        id = int.Parse(this.gameObject.name);
        player = GameObject.Find("mc");
    }

    public void OnRespawn(int id)
    {
        //Res = GameObject.Find("Death & respawn").GetComponent<CheckpointManager>().currentCheckpoint;
        if (id == this.id)
        {
            GameObject.Find("mc").layer = this.gameObject.layer;
            player.transform.position = this.transform.position;
            if(this.id == 1)
            {
                GameObject.Find("dashBetween").GetComponent<PlatformDashBetween>().layer = 0;
            }
            else if (this.id != 1)
            {
                GameObject.Find("dashBetween 2").GetComponent<PlatformDashBetween>().layer = 0;
                GameObject.Find("dashBetween 3").GetComponent<PlatformDashBetween>().layer = 0;
                GameObject.Find("dashBetween 4").GetComponent<PlatformDashBetween>().layer = 0;
            }
        }
    }
    public void OnDisable()
    {
        DoorEvents.current.onDoorTriggerEnter -= OnRespawn;
    }
}
