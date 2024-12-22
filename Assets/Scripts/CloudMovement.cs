using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Sonsuz kaydırma için
        if (rectTransform.anchoredPosition.x > Screen.width)
        {
            rectTransform.anchoredPosition = new Vector2(-Screen.width, rectTransform.anchoredPosition.y);
        }
    }
}
