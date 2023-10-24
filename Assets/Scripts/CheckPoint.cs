using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameObject player;
    private Transform checkpointLocation;
    private bool gotCheckPoint = false;

    void Start()
    {
        gotCheckPoint = false;
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gotCheckPoint && other.gameObject.CompareTag("Player")) 
        {
            checkpointLocation = player.transform;
            player.GetComponent<FirstPersonController>().SetRespawn(checkpointLocation);
        }
    }
}
