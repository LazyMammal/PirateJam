using UnityEngine;

public class FishOutOfWater : MonoBehaviour
{
    public float yMax = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.useGravity = (transform.position.y > yMax);
    }
}
