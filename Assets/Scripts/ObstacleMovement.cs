using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;

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
}
