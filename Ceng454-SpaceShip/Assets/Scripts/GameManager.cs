using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreenCanvas; // Editör üzerinden atama yapýlacak


    void Start()
    {
        Time.timeScale = 1; // Oyunun zamanýný normal hýza ayarla
        deathScreenCanvas.SetActive(false); // Oyun baþlangýcýnda ölüm ekranýný gizle
    }
    public void EndGame()
    {
        Time.timeScale = 0; // Oyun zamanýný durdur
        deathScreenCanvas.SetActive(true); // Oyun sonu ekranýný göster
        Debug.Log("Game Over"); // Konsola oyunun bittiðini logla
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi tekrar yükler
        Time.timeScale = 1;  // Oyunun zamanýný normal hýza geri döndürür
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // "MainMenu" isimli sahneyi yükler
        Time.timeScale = 1;  // Oyunun zamanýný normal hýza geri döndürür
    }
    // Level yükleme fonksiyonlarý
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); // "Level1" isimli sahneyi yükler
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2"); // "Level2" isimli sahneyi yükler
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3"); // "Level3" isimli sahneyi yükler
    }
}
