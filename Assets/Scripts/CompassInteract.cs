using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassInteract : MonoBehaviour
{
    [SerializeField] private int selection = 0;
    public int selection1 = 0;
    public int selection2 = 0;
    public int selection3 = 0;

    public bool madeChoice1 = false;
    public bool madeChoice2 = false;
    public bool madeChoice3 = false;

    private SpriteRenderer sprite1;
    private SpriteRenderer sprite2;
    private SpriteRenderer sprite3;

    void Update()
    {
        ChangeOption();
    }

    void ChangeOption()
    {
        switch(selection)
        {
            case 1:

                break; 
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            default:
                
                break;
        }
    }

    public void ChangeNum()
    {
        if(selection > 8)
        {
            selection = 0;
        }
        else
        {
            selection = selection + 1;
        }
    }

    public void Reset()
    {
        selection1 = 0;
        selection2 = 0;
        selection3 = 0;

        madeChoice1 = false;
        madeChoice2 = false;
        madeChoice3 = false;

        sprite1 = null;
        sprite2 = null;
        sprite3 = null;
    }

}
