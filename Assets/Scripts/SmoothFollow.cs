// Smooth Follow from Standard Assets
// Converted to C# because I fucking hate UnityScript and it's inexistant C# interoperability
// If you have C# code and you want to edit SmoothFollow's vars ingame, use this instead.
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform targetParent;
    private Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public float minTime = 1.5f, maxTime = 3.5f;
    private float nextTime = 0f;


    void LateUpdate()
    {
        float hDamp = heightDamping;
        float rDamp = rotationDamping;

        if (!target || nextTime < Time.time)
        {
			nextTime = Time.time + Random.Range(minTime, maxTime);
            target = targetParent.GetChild(Random.Range(0, targetParent.childCount));
            hDamp = 1.0f / Time.deltaTime;
            rDamp = hDamp;
        }

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rDamp * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, hDamp * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.LookAt(target);
    }
}