using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] private float propulsionForce = -5f;
    [SerializeField] private float destroyTime = 30f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (destroyTime >= Time.deltaTime) 
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() 
    { 
        transform.Translate(transform.forward * propulsionForce * Time.deltaTime);
        
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
