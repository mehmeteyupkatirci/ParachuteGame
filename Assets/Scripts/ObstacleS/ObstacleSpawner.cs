using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private float screenLeftBound;
    private float screenRightBound;

    private float spawnTimer = 0f;

    void Start()
    {
        // Ekran sınırlarını hesapla
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenLeftBound = -screenHalfWidth + 0.5f;
        screenRightBound = screenHalfWidth - 0.5f;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // SpawnRate'e göre engel doğur
        if (spawnTimer >= DifficultyManager.Instance.GetCurrentSpawnRate())
        {
            SpawnObstacle();
            spawnTimer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedObstacle = obstaclePrefabs[randomIndex];

        // Ekran sınırları içinde rastgele bir x pozisyonu oluştur
        float randomX = Random.Range(screenLeftBound, screenRightBound);
        Vector2 spawnPosition = new Vector2(randomX, 6f); // Y pozisyonu üstten başlar
        Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
    }
}
