using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    private FirstPersonController controller;
    private GameObject player;
    private CharacterController characterController;
    void Start()
    {
        player = GameObject.Find("Player");
        controller = GameObject.Find("Player").GetComponent<FirstPersonController>();
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("hit2");
            characterController.enabled = false;
            other.transform.position = controller.respawnPos;
            characterController.enabled = true;
        }
    }
}
