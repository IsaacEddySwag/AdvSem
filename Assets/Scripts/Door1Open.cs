using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Open : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject player;

    private bool isOpen = false;

    public void OpenDoor()
    {
        if(player.GetComponent<PlayerInventory>().card1)
        {
            Debug.Log("1");
            if(!isOpen)
            {
                animator.SetBool("swingOpen", true);
                isOpen = true;
                Debug.Log("2");
            }
            else if(isOpen)
            {
                animator.SetBool("swingOpen", false);
                isOpen = false;
            }
        }
        else
        {
            AudioManager.instance.LockedSFX();
        }
    }
}
