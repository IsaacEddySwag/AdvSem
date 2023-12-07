using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Open : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject player;

    private bool isOpen = false;

    public void OpenDoor()
    {
        if(player.GetComponent<PlayerInventory>().card2)
        {
            if(!isOpen)
            {
                animator.SetBool("isOpening3", true);
                AudioManager.instance.DoorOpenSFX();
                isOpen = true;
            }
            else if(isOpen)
            {
                animator.SetBool("isOpening3", false);
                AudioManager.instance.DoorExitSFX();
                isOpen = false;
            }
        }
        else
        {
            AudioManager.instance.LockedSFX();
        }
    }
}
