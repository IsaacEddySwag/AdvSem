using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float propulsionForce = 0.001f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.up * propulsionForce;
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
