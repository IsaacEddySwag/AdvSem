using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool cameraNil = false;
    public bool movmentNil = false;

    public float drinkFill = 0f;
    public bool hasDrink = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Debug.LogError("More than 1 instance of a manager", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void FillDrink()
    {
        drinkFill += 1;
    }

    public void HasDrink()
    {
        hasDrink = true;
    }

    public void UseDrink()
    {
        hasDrink = false;
    }
}
