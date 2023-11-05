using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class ChairPuzzler : MonoBehaviour
{
    private quaternion quat;
    private Vector3 movePos;
    public TurnPuzzler table;
    public float turnAmount;
    public float moveAmount;
    public UnityEvent correctGuess;
    public UnityEvent incorrectGuess;
    private bool victory = false;
    private bool gotIt = false;
    void Start()
    {
        quat = Quaternion.Euler(transform.rotation.x, turnAmount, transform.rotation.z);
        movePos = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation == quat && !gotIt)
        {
            correctGuess.Invoke();
            gotIt = true;
        }

        if(victory)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePos, 0.5f);
        }
    }

    public void MoveUp()
    {
        victory = true;
    }
}
