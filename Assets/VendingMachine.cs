using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void shakeMachine()
    {
        anim.SetBool("shake", true);
    }
}
