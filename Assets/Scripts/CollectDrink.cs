using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDrink : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.HasDrink();
        Destroy(this.gameObject);
    }
}