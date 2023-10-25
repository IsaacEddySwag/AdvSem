using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float bobbingSpeed = 1f;  // Speed of the bobbing effect
    public float bobbingAmount = 0.5f; // Amount of bobbing effect
    public float downDistance = 0.2f; // Distance the platform moves down when the player lands on it

    private Vector3 originalPosition; // Original position of the platform
    private bool playerOnPlatform = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Bob the platform up and down
        float newY = originalPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;

        // If the player is on the platform, move it down slightly
        if (playerOnPlatform)
        {
            newY -= downDistance;
        }

        // Apply the new Y position to the object's transform
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
