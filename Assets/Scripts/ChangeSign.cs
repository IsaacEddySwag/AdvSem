using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeSign : MonoBehaviour
{
    public TableSwapper tables;
    public float puzzleChoice;


    private void Start()
    {
        tables = GameObject.Find("SwapperTable").GetComponent<TableSwapper>();
    }
    void Update()
    {
        puzzleChoice = tables.getNumber;

        switch(puzzleChoice)
        {
                case 1:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
                case 2:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
                case 3:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                break;
                case 4:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
                case 5:
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
    }
}
