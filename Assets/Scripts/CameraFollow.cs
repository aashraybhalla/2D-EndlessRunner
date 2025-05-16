using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = new Vector3(5f, 2f, -10f);
	public float smoothSpeed = 2f;

	void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothed;
	}
}