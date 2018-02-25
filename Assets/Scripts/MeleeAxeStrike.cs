using UnityEngine;

public class MeleeAxeStrike : MonoBehaviour
{
    public Transform axeIdle, axeSwing;
	public float attackSpeed = 5f, returnSpeed = 3f;
    private Quaternion rotIdle, rotSwing, rotForward, rotBack;
	private float swingTime = 0f, returnTime = 0f;

    void Start()
    {
        axeSwing.gameObject.SetActive(false);
        rotIdle = axeIdle.localRotation;
        rotSwing = axeSwing.localRotation;
		rotBack = rotIdle;
		rotForward = rotIdle;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
			rotBack = axeIdle.localRotation;
			returnTime = 0f;
			swingTime += Time.deltaTime;
			axeIdle.localRotation = Quaternion.Slerp(rotForward, rotSwing, swingTime * attackSpeed);
        }
		else
		{
			rotForward = axeIdle.localRotation;
			swingTime = 0f;
			returnTime += Time.deltaTime;
			axeIdle.localRotation = Quaternion.Slerp(rotBack, rotIdle, returnTime * returnSpeed * Mathf.Lerp(.5f, 1f, returnTime));
		}
    }
}
