using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollectEvent : MonoBehaviour
{
    public UnityEvent collected;
    private void OnTriggerEnter(Collider other)
    {
        collected.Invoke();
        Destroy(other.gameObject);
    }
}
