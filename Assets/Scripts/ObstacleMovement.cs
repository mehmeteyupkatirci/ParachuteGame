using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;
    public float difficultyIncreaseRate = 0.1f; // Hız artış oranı

    void Update()
    {
        // Engel yukarıdan aşağıya hareket eder
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Ekranın dışına çıktıysa yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Zamanla engel hızını artır
        InvokeRepeating("IncreaseSpeed", 10f, 10f); // Her 10 saniyede bir hızı artır
    }

    void IncreaseSpeed()
    {
        speed += difficultyIncreaseRate; // Hız artışı
        Debug.Log("Hız Arttı: " + speed);
    }
}
