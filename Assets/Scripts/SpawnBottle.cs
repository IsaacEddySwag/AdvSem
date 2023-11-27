using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBottle : MonoBehaviour
{
    private bool hasDrink;
    public bool canPickUp = true;
    [SerializeField] private GameObject drinkCollect;
    [SerializeField] private TableSwapper tableSwapper;

    void Update()
    {
        hasDrink = tableSwapper.hasDrink;

        if (!hasDrink && canPickUp == true)
        {
            Instantiate(drinkCollect, transform.position, Quaternion.identity);
            canPickUp = false;
        }

    }

    public void canPickUpActive()
    {
        canPickUp = true;
    }
}
