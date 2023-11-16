using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger: MonoBehaviour
{
    public UnityEvent triggerEvent;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEvent.Invoke();
        }
    }
}
