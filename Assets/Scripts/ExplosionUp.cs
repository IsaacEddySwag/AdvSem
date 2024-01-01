using UnityEngine;

public class ExplosionUp : MonoBehaviour
{
    public float upwardForce = 2f;  
    public float propulsionDuration = 2f;
    public float delayDuration = 4f;

    [SerializeField] private ParticleSystem launchSoda;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        launchSoda.Stop();
    }

    void PropelUpwards()
    {
        rb.useGravity = false;

        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
        launchSoda.Play();
        Invoke("FallDown", propulsionDuration); 
    }

    void FallDown()
    {
        rb.useGravity = true;
        launchSoda.Stop();
        Invoke("PropelUpwards", delayDuration);
    }

    public void ShakeIt()
    {
        PropelUpwards();
    }
}

