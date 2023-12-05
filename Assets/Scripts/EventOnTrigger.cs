using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger: MonoBehaviour
{
    public UnityEvent triggerEventIn;
    public UnityEvent triggerEventOut;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerEventIn.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerEventOut.Invoke();
        }
    }
}
