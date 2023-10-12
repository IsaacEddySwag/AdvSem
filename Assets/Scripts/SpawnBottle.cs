using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBottle : MonoBehaviour
{
    private bool hasDrink;
    private bool canPickUp = true;
    [SerializeField] private GameObject drinkCollect;

    void Update()
    {
        hasDrink = GameManager.Instance.hasDrink;

        if(drinkCollect.scene.IsValid())
        {
            canPickUp = true;
        }

        if (!hasDrink && canPickUp == true)
        {
            Instantiate(drinkCollect, transform.position, Quaternion.identity);
            canPickUp = false;
        }

    }
}
