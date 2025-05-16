using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
	public float destroyOffset = 15f;

	void Update()
	{
		transform.Translate(Vector2.left * GameManager.Instance.gameSpeed * Time.deltaTime);

		if (transform.position.x < -destroyOffset)
		{
			Destroy(gameObject);
		}
	}
}