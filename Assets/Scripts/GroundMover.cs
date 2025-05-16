using UnityEngine;

public class GroundMover : MonoBehaviour
{
	public float groundWidth = 20f;

	void Update()
	{
		if (transform.position.x < -groundWidth)
		{
			transform.position += new Vector3(groundWidth * 2f, 0f, 0f);
		}
	}
}