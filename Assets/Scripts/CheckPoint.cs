using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameObject player;
    private Vector3 checkpointLocation;
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
            checkpointLocation = player.transform.position;
            player.GetComponent<FirstPersonController>().SetRespawn(checkpointLocation);
        }
    }
}
