using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEventManager : MonoBehaviour
{
    public UnityEvent interactEvent;

    public void onPlayerInteract()
    {
        interactEvent.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
