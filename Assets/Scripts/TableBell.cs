using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBell : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void DingerOn()
    {
        animator.SetBool("gotDinged", true);
    }

    public void DingerOff()
    {
        animator.SetBool("gotDinged", false);
    }
}
