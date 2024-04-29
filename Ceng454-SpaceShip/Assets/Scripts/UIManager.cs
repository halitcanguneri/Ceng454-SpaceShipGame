using UnityEngine;
using TMPro;  // TextMeshPro i�in gerekli namespace

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledText;  // D��man say�s� i�in TextMeshPro objesi
    public TextMeshProUGUI playerHealthText;  // Oyuncu can� i�in TextMeshPro objesi

    private int totalEnemiesKilled = 0; // Toplam �ld�r�len d��man say�s�

    public void UpdateEnemiesKilled(int killedCount)
    {
        totalEnemiesKilled += killedCount;
        enemiesKilledText.text = totalEnemiesKilled.ToString();
    }

    public void UpdatePlayerHealth(int currentHealth)
    {
        playerHealthText.text =currentHealth.ToString();
    }
}
