using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    public UnityEvent delayedEvent;

    public void delayEvent(float delay)
    {
        delayedEvent.Invoke();
    }
}
