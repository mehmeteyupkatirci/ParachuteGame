using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Genel ayarlar
    public float fallSpeed = 2f; // Aşağı düşme hızı
    public float difficultyIncreaseRate = 0.1f; // Hız artış oranı

    // Dönen engeller için
    public bool isRotating = false;
    public float rotationSpeed = 100f;

    // Yatay hareket eden engeller için
    public bool isMovingHorizontally = false;
    public float horizontalSpeed = 2f;
    public float horizontalRange = 3f;
    private Vector3 startPosition;

    void Start()
    {
        // Yatay hareket için başlangıç pozisyonunu kaydet
        if (isMovingHorizontally)
        {
            startPosition = transform.position;
        }

        // Zamanla düşme hızını artır
        InvokeRepeating("IncreaseFallSpeed", 10f, 10f);
    }

    void Update()
    {
        // Aşağı doğru düşme hareketi
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Dönen engeller için
        if (isRotating)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        // Yatay hareket eden engeller için
        if (isMovingHorizontally)
        {
            transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange, 0, 0);
        }

        // Ekranın dışına çıkan engelleri yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void IncreaseFallSpeed()
    {
        fallSpeed += difficultyIncreaseRate;
        Debug.Log("Düşme Hızı Arttı: " + fallSpeed);
    }
}
