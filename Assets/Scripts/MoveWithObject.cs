using UnityEngine;

public class MoveWithObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform playerTransform;
    private Rigidbody objectRigidbody;

    void Start()
    {
        // Get the Rigidbody component of the moving object
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        playerTransform = player.transform;
        // Check if the player is colliding with the moving object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Move the player along with the object
            Vector3 movement = objectRigidbody.velocity;
            playerTransform.position += movement * Time.deltaTime;
        }
    }
}