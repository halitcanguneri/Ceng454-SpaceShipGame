using UnityEngine;
using TMPro;  // TextMeshPro için gerekli namespace

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledText;  // Düþman sayýsý için TextMeshPro objesi
    public TextMeshProUGUI playerHealthText;  // Oyuncu caný için TextMeshPro objesi

    private int totalEnemiesKilled = 0; // Toplam öldürülen düþman sayýsý

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
