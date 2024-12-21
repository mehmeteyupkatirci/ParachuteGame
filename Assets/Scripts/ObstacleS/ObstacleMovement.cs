using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public bool isRotating = false;
    public float rotationSpeed = 100f;

    public bool isMovingHorizontally = false;
    public float horizontalSpeed = 2f;
    public float horizontalRange = 3f;
    private Vector3 startPosition;

    private Vector3 movement;

    private float screenLeftBound;
    private float screenRightBound;

    void Start()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenLeftBound = -screenHalfWidth + 0.5f;
        screenRightBound = screenHalfWidth - 0.5f;

        if (isMovingHorizontally)
        {
            startPosition = transform.position;
        }
    }

    void Update()
    {
        movement = Vector3.zero;

        // Aşağı düşme hareketi
        float fallSpeed = DifficultyManager.Instance.GetCurrentFallSpeed();
        movement += Vector3.down * fallSpeed * Time.deltaTime;

        // Dönen engeller
        if (isRotating)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        // Yatay hareket eden engeller
        if (isMovingHorizontally)
        {
            float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange;
            float newX = startPosition.x + horizontalOffset;
            newX = Mathf.Clamp(newX, screenLeftBound, screenRightBound);
            movement.x = newX - transform.position.x;
        }

        // Hareketi uygula
        transform.position += movement;

        // Ekranın dışına çıkan engelleri yok et
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
