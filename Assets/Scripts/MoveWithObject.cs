using UnityEngine;
using UnityEngine.InputSystem;

public class MoveWithObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movingPlatform;
    private Rigidbody rb;

    public bool playerIn = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = true;
            player.transform.SetParent(movingPlatform.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIn = false;
            player.transform.SetParent(null);
        }
    }
}