using UnityEngine;

public class WorldMover : MonoBehaviour
{
	void Update()
	{
		transform.Translate(Vector2.left * GameManager.Instance.gameSpeed * Time.deltaTime);
	}
}