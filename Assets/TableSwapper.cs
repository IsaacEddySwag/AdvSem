using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TableSwapper : MonoBehaviour
{
    private int table1Choice = 0;
    private int table2Choice = 0;

    [SerializeField] private GameObject table1Object;
    [SerializeField] private GameObject table2Object;
    [SerializeField] private GameObject table3Object;
    [SerializeField] private GameObject table4Object;
    [SerializeField] private GameObject table5Object;

    private GameObject moveTable1 = null;
    private GameObject moveTable2 = null;

    [SerializeField] private Transform table1Transform;
    [SerializeField] private Transform table2Transform;

    public float moveSpeed = 0;
    public float delayTime = 0;

    [SerializeField] private bool canStart = false;
    public bool puzzleEnd = false;

    private void Awake()
    {
        moveTable1 = table1Object;
        moveTable2 = table2Object;
    }

    void Update()
    {
        MoveTables(canStart);
    }

    public void ChooseTables()
    {
        table1Choice = Random.Range(1, 5);
        table2Choice = Random.Range(1, 5);

        switch(table1Choice) 
        {
            case 1:
                moveTable1 = table1Object;
                break;
            case 2:
                moveTable1 = table2Object;
                break;
            case 3:
                moveTable1 = table3Object;
                break;
            case 4:
                moveTable1 = table4Object;
                break;
            case 5:
                moveTable1 = table5Object;
                break;
        }

        switch (table2Choice)
        {
            case 1:
                moveTable2 = table1Object;
                break;
            case 2:
                moveTable2 = table2Object;
                break;
            case 3:
                moveTable2 = table3Object;
                break;
            case 4:
                moveTable2 = table4Object;
                break;
            case 5:
                moveTable2 = table5Object;
                break;
        }

        table1Transform = moveTable1.transform;
        table2Transform = moveTable2.transform;

        canStart = true;
    }

    private void MoveTables(bool canStart)
    {
        if(canStart == true)
        {
            moveTable1.transform.position = Vector3.MoveTowards(table1Transform.position, table2Transform.position, moveSpeed);
            moveTable2.transform.position = Vector3.MoveTowards(table2Transform.position, table1Transform.position, moveSpeed);

            if (moveTable1.transform.position == table2Transform.position && moveTable2.transform.position == table1Transform.transform.position && !puzzleEnd)
            {
                canStart = false;
                Invoke("ChooseTables", delayTime);
            }
        }
    }
}
