using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBGControl : MonoBehaviour
{
    public GameObject asteroidPrefab; // Asteroid prefab
    public float spawnInterval = 2f;  // Spawn aralýðý
    public float asteroidLifetime = 10f;  // Asteroidin ekranda kalma süresi

    private float screenTopY;
    private float screenLeftX;
    private float screenRightX;

    void Start()
    {
        // Ekranýn üst sýnýrýný ve yatay sýnýrlarýný hesaplama
        Camera mainCamera = Camera.main;
        screenTopY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1.5f, 0)).y;
        screenLeftX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRightX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // Belirli aralýklarla asteroid spawn etme
        InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);
        
    }

    void SpawnAsteroid()
    {
        // Rastgele bir X pozisyonunda asteroid yaratma
        float spawnX = Random.Range(screenLeftX, screenRightX);
        Vector3 spawnPosition = new Vector3(spawnX, screenTopY, 0);
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Belirlenen süre sonra asteroidi yok et
        Destroy(newAsteroid, asteroidLifetime);
    }
}






