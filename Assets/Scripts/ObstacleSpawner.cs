using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float spawnHeight = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-2.5f, 2.5f); // Oyuncu alanına göre sınırlar
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
