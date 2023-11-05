using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class TurnPuzzler : MonoBehaviour
{
    public float correct;
    private Vector3 movePos;
    public float moveAmount;
    public UnityEvent win;
    private bool victory = false;
    void Start()
    {
        correct = 0f;
        movePos = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
    }

    void Update()
    {
        if(correct >= 6f) 
        {
            Win();
        }

        if (victory)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePos, 0.001f);
        }
    }

    public void CorrectGuess()
    {
        correct += 1f;
    }

    public void Win()
    {
        win.Invoke();
    }

    public void MoveUp()
    {
        victory = true;
    }
}
