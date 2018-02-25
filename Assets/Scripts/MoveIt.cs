using UnityEngine;

public class MoveIt : MonoBehaviour
{
    public float maxSpeed = 25f, maxTorque = 1f;
    public float minTime = 1.5f, maxTime = 3.5f;
    public float probeDistance = 10f;
    private float nextTime = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), probeDistance))
            rb.AddRelativeForce(Vector3.forward * Mathf.Clamp(maxSpeed - Vector3.Magnitude(rb.velocity), -.1f * maxSpeed, maxSpeed) * Time.fixedDeltaTime);

        if (nextTime < Time.time)
        {
			nextTime = Time.time + Random.Range(minTime, maxTime);
			rb.AddRelativeTorque(Vector3.up * maxTorque * Random.Range(-1f, 1f));
        }
    }
}
