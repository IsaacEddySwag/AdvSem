using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float propulsionForce = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * propulsionForce, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.compareTag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
