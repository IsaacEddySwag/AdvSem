using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDrink : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("SwapperTable").GetComponent<TableSwapper>().hasDrink = true;
        Destroy(this.gameObject);
    }
}
