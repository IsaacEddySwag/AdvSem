using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class ChairPuzzler : MonoBehaviour
{
    [SerializeField] private int turned;
    private Vector3 movePos;
    public TurnPuzzler table;
    public float moveAmount;
    [SerializeField] private int correctTurn;
    public UnityEvent correctGuess;
    public UnityEvent incorrectGuess;
    private bool victory = false;
    private bool gotIt = false;
    private float speed = 1f;

    void Start()
    {
        turned = 0;
        movePos = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(turned >= 8)
        {
            turned = 0;
        }

        if(turned == correctTurn && !gotIt)
        {
            correctGuess.Invoke();
            gotIt = true;
        }

        if(victory)
        {
            speed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movePos, 0.5f * Time.deltaTime);
        }
    }

    public void MoveUp()
    {
        victory = true;
    }

    public void Turning()
    {
        turned++;
    }

}
