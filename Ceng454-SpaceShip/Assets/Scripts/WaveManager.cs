using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab; // D��man gemisi prefab�
    public int enemiesPerWave = 6; // Her dalga i�in d��man say�s�
    private int totalEnemiesDestroyed = 0; // Toplam yok edilen d��man say�s�
    private int currentWave = 1; // �u anki dalga numaras�

    public Transform[] spawnPoints; // D��manlar�n spawnlanaca�� noktalar

    void Start()
    {
        StartCoroutine(SpawnWave()); // �lk dalgay� ba�lat
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy(); // D��manlar� spawn et
            yield return new WaitForSeconds(1f); // Her d��man spawn� aras�nda 1 saniye bekle
        }
    }
    
    public void OnEnemyDestroyed()
    {
        totalEnemiesDestroyed++;
        Debug.Log("Destroyed: " + totalEnemiesDestroyed); // Debug ile kontrol
        FindObjectOfType<UIManager>().UpdateEnemiesKilled(1);

        // Her d��man yok edildi�inde bu kontrol� yap
        if (totalEnemiesDestroyed % enemiesPerWave == 0)
        {
            if (totalEnemiesDestroyed == 18) // 18 d��man yok edildiyse son
            {
                GoToNextLevel(); // Yeni b�l�me ge�
            }
            else
            {
                currentWave++; // Dalga numaras�n� art�r
                Debug.Log("Starting new wave: " + currentWave); // Debug ile dalga kontrol�
                StartCoroutine(SpawnWave()); // Yeni dalgay� ba�lat
            }
        }
    }

    void SpawnEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }

    public void GoToNextLevel()
    {
        // �u anki sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // Sonraki sahnenin indeksini hesapla

        // Sahne say�s�n� kontrol et
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Sonraki sahneyi y�kle
        }
        else
        {
            Debug.Log("This is the last level."); // E�er son sahnedeyse, bir log yaz
            // Burada isterseniz ana men�ye d�nebilir veya oyunu bitirebilirsiniz.
        }
    }
}
