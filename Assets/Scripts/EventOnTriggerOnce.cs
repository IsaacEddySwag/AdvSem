using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTriggerOnce: MonoBehaviour
{
    public UnityEvent triggerEvent;
    [SerializeField] private bool triggerFired = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!triggerFired)
            {
                triggerEvent.Invoke();
                triggerFired = true;
            }
        }
    }
}
