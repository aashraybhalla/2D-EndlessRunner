using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] powerUpPrefabs;
    public GameObject coinPrefab;

    public float obstacleSpawnInterval = 1.5f;
    public float coinSpawnInterval = 5f;
    public float powerUpSpawnInterval = 8f;

    private float obstacleTimer;
    private float coinTimer;
    private float powerUpTimer;

    public Transform parentTransform;

    void Update()
    {
        obstacleTimer += Time.deltaTime;
        coinTimer += Time.deltaTime;
        powerUpTimer += Time.deltaTime;

        if (obstacleTimer >= obstacleSpawnInterval)
        {
            SpawnObstacle();
            obstacleTimer = 0f;
        }

        if (coinTimer >= coinSpawnInterval)
        {
            if (Random.value < 0.5f) // 50% chance
                SpawnCoin();
            coinTimer = 0f;
        }

        if (powerUpTimer >= powerUpSpawnInterval)
        {
            if (Random.value < 0.3f) // 30% chance
                SpawnPowerUp();
            powerUpTimer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float spawnX = 12f; // Relative to player
        float spawnY = -4f;

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
        int index = Random.Range(0, obstaclePrefabs.Length);

        GameObject newObstacle = Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity, parentTransform);

        // Optional: Vary size or scale
        float randomScale = Random.Range(0.8f, 1.2f);
        newObstacle.transform.localScale = new Vector3(randomScale, randomScale, 1f);
    }

    void SpawnPowerUp()
    {
        float spawnX = 14f;
        float spawnY = Random.Range(-2f, 1.5f);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
        int index = Random.Range(0, powerUpPrefabs.Length);

        Instantiate(powerUpPrefabs[index], spawnPos, Quaternion.identity, parentTransform);
    }

    void SpawnCoin()
    {
        float spawnX = 13f;
        float spawnY = Random.Range(-2f, 2f);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
        Instantiate(coinPrefab, spawnPos, Quaternion.identity, parentTransform);
    }
}
