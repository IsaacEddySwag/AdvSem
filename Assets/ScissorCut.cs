using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public float rotationAmount = 45f; // Specify the amount of rotation in degrees
    public float rotationSpeed = 90f; // Specify the rotation speed in degrees per second
    public float waitTimeBeforeRotate = 1f; // Specify the time to wait before rotating again in seconds
    public float waitTimeBeforeReset = 1f; // Specify the time to wait before resetting the rotation in seconds

    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
        // Start the rotation coroutine
        StartCoroutine(RotateObjectCoroutine());
    }

    private IEnumerator RotateObjectCoroutine()
    {
        while (true) // Infinite loop for continuous rotation
        {
            // Rotate the object by the specified amount on the z-axis
            Quaternion targetRotation = Quaternion.Euler(0, 0, rotationAmount);
            float elapsedTime = 0f;
            while (elapsedTime < 1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, elapsedTime * rotationSpeed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Wait for the specified duration before resetting the rotation
            yield return new WaitForSeconds(waitTimeBeforeReset);

            // Reset the rotation to the original position
            float resetTime = 0f;
            while (resetTime < 1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, resetTime * rotationSpeed * Time.deltaTime);
                resetTime += Time.deltaTime;
                yield return null;
            }

            // Wait for the specified duration before rotating again
            yield return new WaitForSeconds(waitTimeBeforeRotate);
        }
    }
}
