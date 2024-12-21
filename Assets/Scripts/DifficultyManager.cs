using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    // Düşme hızı
    public float fallSpeed = 2f;
    public float fallSpeedIncreaseRate = 0.1f;

    // Doğma hızı
    public float spawnRate = 2f;
    public float minimumSpawnRate = 0.5f;
    public float spawnRateIncreaseRate = 0.1f;

    private float timeSinceLastIncrease = 0f;
    public float difficultyIncreaseInterval = 10f; // Kaç saniyede bir zorluk artacak

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= difficultyIncreaseInterval)
        {
            IncreaseDifficulty();
            timeSinceLastIncrease = 0f;
        }
    }

    private void IncreaseDifficulty()
    {
        // Düşme hızını artır
        fallSpeed += fallSpeedIncreaseRate;

        // Doğma hızını artır
        if (spawnRate > minimumSpawnRate)
        {
            spawnRate -= spawnRateIncreaseRate;
        }

        Debug.Log($"Düşme Hızı: {fallSpeed}, Doğma Hızı: {spawnRate}");
    }

    public float GetCurrentFallSpeed()
    {
        return fallSpeed;
    }

    public float GetCurrentSpawnRate()
    {
        return spawnRate;
    }
}
