using UnityEngine;

public class InfiniRotation : MonoBehaviour
{
    // Speed of rotation in degrees per second
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
