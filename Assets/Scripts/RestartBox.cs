using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    public float damage = 1f;

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
            controller.TakeDamage(damage);
            characterController.enabled = true;
        }
    }
}
