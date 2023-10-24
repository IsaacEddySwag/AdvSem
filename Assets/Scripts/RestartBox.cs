using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    private FirstPersonController controller;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        controller = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = controller.respawnPos.position;
        }
    }
}
