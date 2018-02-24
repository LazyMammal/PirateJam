using UnityEngine;

public class WaveHeightPeep : MonoBehaviour
{
    void FixedUpdate()
    {
		float distance = 5f;
		Ray ray = new Ray(Camera.main.transform.position + Vector3.up * distance, Vector3.down);
		RaycastHit hit;

        Physics.Raycast(ray, out hit, distance * 2f, 4);

		/*
		Debug.Log("=====");
		Debug.Log(ray.origin);
		Debug.Log(hit.point);
		*/
    }
}
