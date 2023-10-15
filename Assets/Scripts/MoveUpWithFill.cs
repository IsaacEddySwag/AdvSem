
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpWithFill : MonoBehaviour
{
    public float fillDrink;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.drinkFill == 15)
        {
            fillDrink = GameManager.Instance.drinkFill * 2;

            transform.position = new Vector3(transform.position.x, transform.position.y + fillDrink, transform.position.z);
        }
    }
}
