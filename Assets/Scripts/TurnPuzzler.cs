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
    private float speed = 1f;
    public float completeAmount;
    void Start()
    {
        correct = 0f;
        movePos = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
    }

    void Update()
    {
        if(correct >= completeAmount) 
        {
            Win();
        }

        if (victory)
        {
            speed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movePos, 0.5f * Time.deltaTime);
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
