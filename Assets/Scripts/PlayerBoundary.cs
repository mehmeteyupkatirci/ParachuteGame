using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private float minX, maxX, minY, maxY;

    void Start()
    {
        CalculateCameraBounds();
    }

    void Update()
    {
        ClampPlayerPosition();
    }

    void CalculateCameraBounds()
    {
        // Main Camera'yı al
        Camera mainCamera = Camera.main;

        // Kameranın boyutlarını hesapla
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Sınırları belirle
        minX = mainCamera.transform.position.x - (cameraWidth / 2);
        maxX = mainCamera.transform.position.x + (cameraWidth / 2);
        minY = mainCamera.transform.position.y - (cameraHeight / 2);
        maxY = mainCamera.transform.position.y + (cameraHeight / 2);
    }

    void ClampPlayerPosition()
    {
        // Karakterin pozisyonunu sınırlar içinde tut
        Vector3 clampedPosition = transform.position;

        // X ve Y pozisyonlarını sınırlıyoruz
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }

    // Eğer kamera hareket ediyorsa, sınırları güncellemek gerekebilir
    void LateUpdate()
    {
        CalculateCameraBounds();
    }
}
