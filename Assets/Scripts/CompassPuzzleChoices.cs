using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassPuzzleChoices : MonoBehaviour
{
    public int part1 = 0;
    public int part2 = 0;
    public int part3 = 0;

    private int playerChoice1 = 0;
    private int playerChoice2 = 0;
    private int playerChoice3 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewChoices()
    {
        part1 = Random.Range(1, 9);
        part2 = Random.Range(1, 9);
        part3 = Random.Range(1, 9);

        while(part1 == part2) 
        {
            part2 = Random.Range(1, 9);
        }

        while (part1 == part3)
        {
            part3 = Random.Range(1, 9);
        }

        while (part2 == part3)
        {
            part3 = Random.Range(1, 9);
        }
    }
}
