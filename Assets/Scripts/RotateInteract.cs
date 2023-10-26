using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInteract : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool rotateNow = false;
    private Quaternion targetRotation = Quaternion.identity;

    private void Awake()
    {
        rotationSpeed = 0.0001f;
    }

    void Update()
    {
        //var step = Mathf.Pow(Time.deltaTime, rotationSpeed);
        var step = rotationSpeed;


        if (rotateNow)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, step);

            if (Quaternion.Dot(transform.rotation, targetRotation) > 0.9f || Quaternion.Dot(transform.rotation, targetRotation) < -0.9f) // Difference threshold - gusg21
            {
                transform.rotation = targetRotation;
                rotateNow = false;
            }
        }
    }

    public void Rotate45()
    {
        if(!rotateNow) 
        {
            rotateNow = true;
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 45, transform.eulerAngles.z);
        }
    }
    public void RotateMinus45()
    {
        if (!rotateNow)
        {
            rotateNow = true;
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 45, transform.eulerAngles.z);
        }
    }
}
