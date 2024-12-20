using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;
    public bool isGameOver;

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime; // Hayatta kalınan süreye göre puan
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
