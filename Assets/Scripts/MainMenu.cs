using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesine geçiş yap
        SceneManager.LoadScene("GameScene"); // Oyun sahnenizin adını buraya yazın
    }

    public void QuitGame()
    {
        Debug.Log("Oyun Kapatıldı!");
        Application.Quit(); // Oyun uygulamasını kapatır
    }
}
