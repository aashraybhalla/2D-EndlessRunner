using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject[] obstaclePrefabs;
	public float spawnInterval = 2f;
	private float timer;
	public Transform parentTransform;

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			SpawnObstacle();
			timer = 0f;
		}
	}

	void SpawnObstacle()
	{
		float spawnX = Camera.main.transform.position.x + 10f;
		float spawnY = -4.5f; // Adjust to ground height
		Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);

		int index = Random.Range(0, obstaclePrefabs.Length);
		GameObject newObstacle = Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity, parentTransform);
	}
}