using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Farklı engellerin listesi
    public float spawnRate = 2f;
    public float minimumSpawnRate = 0.5f; // En düşük doğma hızı
    public float difficultyIncreaseRate = 0.1f; // Doğma hızı artış oranı

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, spawnRate);
        InvokeRepeating("IncreaseDifficulty", 10f, 10f); // Her 10 saniyede zorluğu artır
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedObstacle = obstaclePrefabs[randomIndex];

        float randomX = Random.Range(-8f, 8f);
        Vector2 spawnPosition = new Vector2(randomX, 6f);
        Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        if (spawnRate > minimumSpawnRate)
        {
            spawnRate -= difficultyIncreaseRate; // Doğma hızını artır (yani daha hızlı engeller doğar)
            CancelInvoke("SpawnObstacle");
            InvokeRepeating("SpawnObstacle", 0f, spawnRate);
            Debug.Log("Engel Doğma Süresi Azaldı: " + spawnRate);
        }
    }
}
