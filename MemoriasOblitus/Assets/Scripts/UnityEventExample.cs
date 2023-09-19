using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExample : MonoBehaviour
{
    public UnityEvent OnSphereTouch;

    public void OnTriggerEnter(Collider other)
    {
        OnSphereTouch.Invoke();
        Destroy(this.gameObject);
    }
}
