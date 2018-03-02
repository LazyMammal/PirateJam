using UnityEngine;

[RequireComponent(typeof(AudioClip))]
public class MeleeHitSound : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
		if (Input.GetButton("Fire1"))
			GetComponent<AudioSource>().Play();
    }
}
