using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSwapper : MonoBehaviour
{
   private int table1Choice = 0;
   private int table2Choice = 0;

   public int checkNum = 0;
   public int getNumber = 0;

   [SerializeField] private GameObject table1Object;
   [SerializeField] private GameObject table2Object;
   [SerializeField] private GameObject table3Object;
   [SerializeField] private GameObject table4Object;
   [SerializeField] private GameObject table5Object;

   [SerializeField] private GameObject moveTable1;
   [SerializeField] private GameObject moveTable2;

   [SerializeField] private Vector3 original1Loc;
   [SerializeField] private Vector3 original2Loc;

   public float moveSpeed = 0f;
   public float delayTime = 0f;
   public float delayTime2 = 0f;

   private Vector3 lastPos1;
   private Vector3 lastPos2;

   [SerializeField] private bool canStart = false;
   public bool puzzleEnd = false;
   public bool hasBooze;

    public GameObject endDoor;
   
   private void Awake()
   {
       moveTable1 = table1Object;
       moveTable2 = table2Object;
       NewOne();
   }

   void Update()
   {
        hasBooze = GameManager.Instance.hasDrink;

        if (canStart == true)
        {
            lastPos1 = new Vector3(moveTable1.transform.position.x, moveTable1.transform.position.y, moveTable1.transform.position.z);
            lastPos2 = new Vector3(moveTable2.transform.position.x, moveTable2.transform.position.y, moveTable2.transform.position.z);

            moveTable1.transform.position = Vector3.MoveTowards(moveTable1.transform.position, original2Loc, moveSpeed);
            moveTable2.transform.position = Vector3.MoveTowards(moveTable2.transform.position, original1Loc, moveSpeed);

            if (moveTable1.transform.position == lastPos1 && moveTable2.transform.position == lastPos2 && !puzzleEnd)
            {
                Debug.Log("A");
                canStart = false;
                Invoke("ChooseTables", delayTime);
            }
        }

        CheckFinish();
    }
    
    public void ChooseTables()
    {
        table1Choice = Random.Range(1, 6);
        table2Choice = Random.Range(1, 6);

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

        original1Loc = new Vector3(moveTable1.transform.position.x, moveTable1.transform.position.y, moveTable1.transform.position.z);
        original2Loc = new Vector3(moveTable2.transform.position.x, moveTable2.transform.position.y, moveTable2.transform.position.z);

        canStart = true;
    }
    
    public void ChoiceSwapper(int number)
    {
        if(hasBooze)
        {
            Debug.Log("Hit2");
            checkNum = number;
            if (checkNum == getNumber)
            {
                Debug.Log("Hit3");
                GameManager.Instance.FillDrink();
                GameManager.Instance.UseDrink();
                NewOne();
            }
            else
            {

            }
        }
    }

    public void NewOne()
    {
        getNumber = Random.Range(1, 6);
    }

    public void CheckFinish()
    {
        if(GameManager.Instance.drinkFill == 5)
        {
            ChooseTables();
        }
        else if(GameManager.Instance.drinkFill >= 10)
        {
            delayTime = delayTime2;
            moveSpeed *= 2;
        }
        else if(GameManager.Instance.drinkFill >= 15)
        {
            puzzleEnd = true;
            endDoor.SetActive(false);
        }
    }
}


