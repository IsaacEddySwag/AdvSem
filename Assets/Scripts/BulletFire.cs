using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float propulsionForce = -5f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    { 
        transform.Translate(transform.forward * propulsionForce * Time.deltaTime);
        var destroyTime = 120;
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
