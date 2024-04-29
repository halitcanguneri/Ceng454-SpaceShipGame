using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreenCanvas; // Edit�r �zerinden atama yap�lacak


    void Start()
    {
        Time.timeScale = 1; // Oyunun zaman�n� normal h�za ayarla
        deathScreenCanvas.SetActive(false); // Oyun ba�lang�c�nda �l�m ekran�n� gizle
    }
    public void EndGame()
    {
        Time.timeScale = 0; // Oyun zaman�n� durdur
        deathScreenCanvas.SetActive(true); // Oyun sonu ekran�n� g�ster
        Debug.Log("Game Over"); // Konsola oyunun bitti�ini logla
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi tekrar y�kler
        Time.timeScale = 1;  // Oyunun zaman�n� normal h�za geri d�nd�r�r
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // "MainMenu" isimli sahneyi y�kler
        Time.timeScale = 1;  // Oyunun zaman�n� normal h�za geri d�nd�r�r
    }
    // Level y�kleme fonksiyonlar�
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); // "Level1" isimli sahneyi y�kler
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2"); // "Level2" isimli sahneyi y�kler
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3"); // "Level3" isimli sahneyi y�kler
    }
}
