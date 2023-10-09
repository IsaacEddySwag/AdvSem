using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionUp : MonoBehaviour
{
    public float launchForce = 10f; // The force with which the object is launched
    public float gravity = -9.8f;    // Gravity pulling the object down

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();

        // Call the LaunchObject method repeatedly using InvokeRepeating
        InvokeRepeating("LaunchObject", 0f, waitTime);
    }

    void LaunchObject()
    {
        // Reset the object's position and velocity
        rb.position = new Vector3(0f, 0f, 0f);
        rb.velocity = Vector3.zero;

        // Apply a force to launch the object into the air
        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
    }

    void Update()
    {
        // Apply gravity to make the object fall back down
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
    }

}
