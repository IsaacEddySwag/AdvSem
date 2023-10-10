using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassPuzzleChoices : MonoBehaviour
{
    public float delaySpeed = 2f;

    [SerializeField] private CompassInteract compass;

    public int part1 = 0;
    public int part2 = 0;
    public int part3 = 0;

    public int puzzlesCompleted = 0;

    public int playerChoice1 = 0;
    public int playerChoice2 = 0;
    public int playerChoice3 = 0;

    [SerializeField] private SpriteRenderer playerSprite1;
    [SerializeField] private SpriteRenderer playerSprite2;
    [SerializeField] private SpriteRenderer playerSprite3;

    [SerializeField] private SpriteRenderer puzzleSprite1;
    [SerializeField] private SpriteRenderer puzzleSprite2;
    [SerializeField] private SpriteRenderer puzzleSprite3;

    [SerializeField] private Sprite puzzleChoice0;
    [SerializeField] private Sprite puzzleChoice1;
    [SerializeField] private Sprite puzzleChoice2;
    [SerializeField] private Sprite puzzleChoice3;
    [SerializeField] private Sprite puzzleChoice4;
    [SerializeField] private Sprite puzzleChoice5;
    [SerializeField] private Sprite puzzleChoice6;
    [SerializeField] private Sprite puzzleChoice7;
    [SerializeField] private Sprite puzzleChoice8;

    private void Start()
    {
        puzzleSprite1.sprite = puzzleChoice0;
        puzzleSprite2.sprite = puzzleChoice0;
        puzzleSprite3.sprite = puzzleChoice0;
    }

    // Update is called once per frame
    void Update()
    {
        playerChoice1 = compass.selection1;
        playerChoice2 = compass.selection2;
        playerChoice3 = compass.selection3;
    }

    public void NewChoices()
    {
        part1 = Random.Range(1, 9);
        part2 = Random.Range(1, 9);
        part3 = Random.Range(1, 9);

        while (part1 == part2)
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

    public void SetSpritesPuzzle()
    {
        PuzzleChange1();
        Invoke("PuzzleChange2", delaySpeed);
        Invoke("PuzzleChange3", delaySpeed + delaySpeed);
    }

    private void PuzzleChange1()
    {
        switch (part1)
        {
            case 1:
                puzzleSprite1.sprite = puzzleChoice1;
                break;
            case 2:
                puzzleSprite1.sprite = puzzleChoice2;
                break;
            case 3:
                puzzleSprite1.sprite = puzzleChoice3;
                break;
            case 4:
                puzzleSprite1.sprite = puzzleChoice4;
                break;
            case 5:
                puzzleSprite1.sprite = puzzleChoice5;
                break;
            case 6:
                puzzleSprite1.sprite = puzzleChoice6;
                break;
            case 7:
                puzzleSprite1.sprite = puzzleChoice7;
                break;
            case 8:
                puzzleSprite1.sprite = puzzleChoice8;
                break;
        }
    }

    private void PuzzleChange2()
    {
        switch (part2)
        {
            case 1:
                puzzleSprite2.sprite = puzzleChoice1;
                break;
            case 2:
                puzzleSprite2.sprite = puzzleChoice2;
                break;
            case 3:
                puzzleSprite2.sprite = puzzleChoice3;
                break;
            case 4:
                puzzleSprite2.sprite = puzzleChoice4;
                break;
            case 5:
                puzzleSprite2.sprite = puzzleChoice5;
                break;
            case 6:
                puzzleSprite2.sprite = puzzleChoice6;
                break;
            case 7:
                puzzleSprite2.sprite = puzzleChoice7;
                break;
            case 8:
                puzzleSprite2.sprite = puzzleChoice8;
                break;
        }
    }

    private void PuzzleChange3()
    {
        switch (part3)
        {
            case 1:
                puzzleSprite3.sprite = puzzleChoice1;
                break;
            case 2:
                puzzleSprite3.sprite = puzzleChoice2;
                break;
            case 3:
                puzzleSprite3.sprite = puzzleChoice3;
                break;
            case 4:
                puzzleSprite3.sprite = puzzleChoice4;
                break;
            case 5:
                puzzleSprite3.sprite = puzzleChoice5;
                break;
            case 6:
                puzzleSprite3.sprite = puzzleChoice6;
                break;
            case 7:
                puzzleSprite3.sprite = puzzleChoice7;
                break;
            case 8:
                puzzleSprite3.sprite = puzzleChoice8;
                break;
        }
    }

    public void CheckComplete()
    {
        if(playerChoice1 == part1)
        {

            if (playerChoice2 == part2) 
            {  

                if(playerChoice3 == part3)
                {
                    puzzlesCompleted += 1;
                    compass.Reset();
                }
            }
        }
    }
}
