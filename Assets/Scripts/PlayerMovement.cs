using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject gameOverText;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Oyun Bitti!");
            Time.timeScale = 0; // Oyunu durdur
            gameOverText.SetActive(true); // Mesajı göster
        }
    }
}
