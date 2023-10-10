using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassInteract : MonoBehaviour
{
    [SerializeField] CompassPuzzleChoices compassPuzzle;

    [SerializeField] private int selection = 1;
    public int selection1 = 0;
    public int selection2 = 0;
    public int selection3 = 0;

    public bool madeChoice1 = false;
    public bool madeChoice2 = false;
    public bool madeChoice3 = false;

    [SerializeField] private SpriteRenderer sprite1;
    [SerializeField] private SpriteRenderer sprite2;
    [SerializeField] private SpriteRenderer sprite3;

    [SerializeField] private Sprite spriteNull;
    [SerializeField] private Sprite puzzleChoice1;
    [SerializeField] private Sprite puzzleChoice2;
    [SerializeField] private Sprite puzzleChoice3;
    [SerializeField] private Sprite puzzleChoice4;
    [SerializeField] private Sprite puzzleChoice5;
    [SerializeField] private Sprite puzzleChoice6;
    [SerializeField] private Sprite puzzleChoice7;
    [SerializeField] private Sprite puzzleChoice8;

    void Update()
    {
        ChangeOption();

    }

    void ChangeOption()
    {
        switch(selection)
        {
            case 1:
                if(!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice1;
                }
                else if(madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice1;
                }
                else
                {
                    sprite3.sprite = puzzleChoice1;
                }
                break; 
            case 2:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice2;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice2;
                }
                else
                {
                    sprite3.sprite = puzzleChoice2;
                }
                break;
            case 3:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice3;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice3;
                }
                else
                {
                    sprite3.sprite = puzzleChoice3;
                }
                break;
            case 4:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice4;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice4;
                }
                else
                {
                    sprite3.sprite = puzzleChoice4;
                }
                break;
            case 5:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice5;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice5;
                }
                else
                {
                    sprite3.sprite = puzzleChoice6;
                }
                break;
            case 6:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice6;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice6;
                }
                else
                {
                    sprite3.sprite = puzzleChoice6;
                }
                break;
            case 7:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice7;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice7;
                }
                else
                {
                    sprite3.sprite = puzzleChoice7;
                }
                break;
            case 8:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = puzzleChoice8;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = puzzleChoice8;
                }
                else
                {
                    sprite3.sprite = puzzleChoice8;
                }
                break;
            default:
                if (!madeChoice1 && !madeChoice2)
                {
                    sprite1.sprite = spriteNull;
                }
                else if (madeChoice1 && !madeChoice2)
                {
                    sprite2.sprite = spriteNull;
                }
                else
                {
                    sprite3.sprite = spriteNull;
                }
                break;
        }
    }

    public void ChangeNum()
    {
        if(selection > 8)
        {
            selection = 0;
        }
        else if(selection < 1)
        {
            selection = 8;
        }
    }

    public void Reset()
    {
        selection = 1;

        selection1 = 0;
        selection2 = 0;
        selection3 = 0;

        madeChoice1 = false;
        madeChoice2 = false;
        madeChoice3 = false;

        sprite1.sprite = spriteNull;
        sprite2.sprite = spriteNull;
        sprite3.sprite = spriteNull;

        compassPuzzle.NewChoices();
        compassPuzzle.SetSpritesPuzzle();
    }

    public void MovePlus()
    {
        selection += 1;
        ChangeNum();
    }

    public void MoveMinus()
    {
        selection -= 1;
        ChangeNum();
    }

    public void MakeSelection()
    {
        if(!madeChoice1 && !madeChoice2)
        {
            selection = 1;
            selection1 = selection;
            madeChoice1 = true;
        }
        else if(madeChoice1 && !madeChoice2)
        {
            selection = 1;
            selection2 = selection;
            madeChoice2 = true;
        }
        else
        {
            selection3 = selection;
            madeChoice3 = true;
        }

        if(madeChoice1 && madeChoice2 && madeChoice3)
        {
            compassPuzzle.CheckComplete();
        }
    }
}
