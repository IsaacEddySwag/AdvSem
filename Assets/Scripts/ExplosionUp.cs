using UnityEngine;

public class ExplosionUp : MonoBehaviour
{
    public float upwardForce = 2f;  
    public float propulsionDuration = 2f;
    public float delayDuration = 4f;
    private bool shaken = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(shaken)
        {
            PropelUpwards();
        }
    }

    void PropelUpwards()
    {
        rb.useGravity = false;

        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
        Invoke("FallDown", propulsionDuration);
    }

    void FallDown()
    {
        rb.useGravity = true;
        Invoke("PropelUpwards", delayDuration);
    }

    public void ShakeIt()
    {
        shaken = true;
    }
}

