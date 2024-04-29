using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþman gemisi prefabý
    public int enemiesPerWave = 6; // Her dalga için düþman sayýsý
    private int totalEnemiesDestroyed = 0; // Toplam yok edilen düþman sayýsý
    private int currentWave = 1; // Þu anki dalga numarasý

    public Transform[] spawnPoints; // Düþmanlarýn spawnlanacaðý noktalar

    void Start()
    {
        StartCoroutine(SpawnWave()); // Ýlk dalgayý baþlat
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy(); // Düþmanlarý spawn et
            yield return new WaitForSeconds(1f); // Her düþman spawný arasýnda 1 saniye bekle
        }
    }
    
    public void OnEnemyDestroyed()
    {
        totalEnemiesDestroyed++;
        Debug.Log("Destroyed: " + totalEnemiesDestroyed); // Debug ile kontrol
        FindObjectOfType<UIManager>().UpdateEnemiesKilled(1);

        // Her düþman yok edildiðinde bu kontrolü yap
        if (totalEnemiesDestroyed % enemiesPerWave == 0)
        {
            if (totalEnemiesDestroyed == 18) // 18 düþman yok edildiyse son
            {
                GoToNextLevel(); // Yeni bölüme geç
            }
            else
            {
                currentWave++; // Dalga numarasýný artýr
                Debug.Log("Starting new wave: " + currentWave); // Debug ile dalga kontrolü
                StartCoroutine(SpawnWave()); // Yeni dalgayý baþlat
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
        // Þu anki sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // Sonraki sahnenin indeksini hesapla

        // Sahne sayýsýný kontrol et
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Sonraki sahneyi yükle
        }
        else
        {
            Debug.Log("This is the last level."); // Eðer son sahnedeyse, bir log yaz
            // Burada isterseniz ana menüye dönebilir veya oyunu bitirebilirsiniz.
        }
    }
}
