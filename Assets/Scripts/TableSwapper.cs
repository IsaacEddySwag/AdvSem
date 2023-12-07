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

    [SerializeField] private GameObject keyCard2;


    public float drinkFill = 0f;
   public bool hasDrink = false;

   [SerializeField] bool puzzleEnd = false;
    private bool swapStart = false;

    public UnityEvent soundPlay;

    public GameObject endDoor;

    public GameObject object1;
    public GameObject object2;

    public float swapSpeed = 1.0f;
    public float waitTime = 2.0f;

    void Start()
    {
        NewOne();
    }   

    IEnumerator SwapObjects()
    {
        while (!puzzleEnd && swapStart)
        {
            Debug.Log("B");

            // Choose two new objects randomly from a list of 5
            GameObject newObject1 = GetRandomObject();
            GameObject newObject2 = GetRandomObject();

            while(newObject1 == newObject2)
            {
                newObject2 = GetRandomObject();
            }

            object1 = newObject1;
            object2 = newObject2;

            // Store original positions
            Vector3 originalPos1 = object1.transform.position;
            Vector3 originalPos2 = object2.transform.position;

            // Lerp to swap positions
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                object1.transform.position = Vector3.Lerp(originalPos1, originalPos2, elapsedTime);
                object2.transform.position = Vector3.Lerp(originalPos2, originalPos1, elapsedTime);
                elapsedTime += Time.deltaTime * swapSpeed;
                yield return null;
            }

            // Wait for some time
            yield return new WaitForSeconds(waitTime);
        }
    }

    GameObject GetRandomObject()
    {
        // You can modify this based on your actual object list
        GameObject[] objectList = { table1Object, table2Object, table3Object, table4Object, table5Object };
        return objectList[Random.Range(0, objectList.Length)];
    }

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
            swapStart = true;
            StartCoroutine(SwapObjects());
        }
        else if(drinkFill == 10)
        {
            waitTime /= 2;
            swapSpeed *= 2;
        }
        else if(drinkFill == 15)
        {
            puzzleEnd = true;
            keyCard2.SetActive(true);
        }
    }
}


