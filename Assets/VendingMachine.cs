using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool shaked = false;

    public void ShakeMachine()
    {
        if(!shaked)
        {
            anim.SetBool("shake", true);
            shaked = true;
        }
    }

    public void StopMachine()
    {
        anim.SetBool("shake", false);
    }
}
