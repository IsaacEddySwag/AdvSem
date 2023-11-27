using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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

    /*
   [SerializeField] private GameObject moveTable1;
   [SerializeField] private GameObject moveTable2;

   [SerializeField] private Vector3 original1Loc;
   [SerializeField] private Vector3 original2Loc;*/

   public float drinkFill = 0f;
   public bool hasDrink = false;

   /*public float moveSpeed = 0f;
   public float delayTime = 0f;
   public float delayTime2 = 0f;

   private Vector3 lastPos1;
   private Vector3 lastPos2;*/

   [SerializeField] bool puzzleEnd = false;

    public UnityEvent soundPlay;

    public GameObject endDoor;

    public GameObject object1;
    public GameObject object2;

    public float swapSpeed = 1.0f;
    public float waitTime = 2.0f;

    void Start()
    {
        StartCoroutine(SwapObjects());
        NewOne();
    }

    IEnumerator SwapObjects()
    {
        while (!puzzleEnd)
        {
            Debug.Log("B");

            // Choose two new objects randomly from a list of 5
            GameObject newObject1 = GetRandomObject();
            GameObject newObject2 = GetRandomObject();

            while(newObject1 == newObject2)
            {
                newObject2 = GetRandomObject();
            }

            // Store original positions
            Vector3 originalPos1 = object1.transform.position;
            Vector3 originalPos2 = object2.transform.position;

            // Lerp to swap positions
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                object1.transform.position = Vector3.Lerp(originalPos1, newObject2.transform.position, elapsedTime);
                object2.transform.position = Vector3.Lerp(originalPos2, newObject1.transform.position, elapsedTime);
                elapsedTime += Time.deltaTime * swapSpeed;
                yield return null;
            }

            // Ensure objects are at final positions
            object1.transform.position = newObject2.transform.position;
            object2.transform.position = newObject1.transform.position;

            // Wait for some time
            yield return new WaitForSeconds(waitTime);
        }
    }

    GameObject GetRandomObject()
    {
        // You can modify this based on your actual object list
        GameObject[] objectList = {table1Object, table2Object, table3Object, table4Object, table5Object };
        return objectList[Random.Range(0, objectList.Length)];
    }
    /* void Update()
     {
         if (canStart)
         {
             float t = moveSpeed * Time.deltaTime;

             moveTable1.transform.position = Vector3.Lerp(moveTable1.transform.position, original2Loc, t);
             moveTable2.transform.position = Vector3.Lerp(moveTable2.transform.position, original1Loc, t);

             float distance1 = Vector3.Distance(moveTable1.transform.position, original2Loc);
             float distance2 = Vector3.Distance(moveTable2.transform.position, original1Loc);

             Debug.Log(distance2 + " " + distance1);

             if (distance1 < 0.01f && distance2 < 0.01f && !puzzleEnd)
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
     }*/

    public void ChoiceSwapper(int number)
    {
        if(hasDrink)
        {
            checkNum = number;
            if (checkNum == getNumber)
            {
                drinkFill += 1;
                hasDrink = false;
                NewOne();
                CheckFinish();
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
        if (drinkFill == 5)
        {
            Debug.Log("A");
            StartCoroutine(SwapObjects());
        }
        else if(drinkFill >= 10)
        {
            waitTime /= 2;
            swapSpeed *= 2;
        }
        else if(drinkFill >= 15)
        {
            puzzleEnd = true;
            Destroy(endDoor);
        }
    }
}


