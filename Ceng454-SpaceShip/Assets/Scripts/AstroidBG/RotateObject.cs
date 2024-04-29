using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float minRotationSpeed = -30f;  // Minimum dönüþ hýzý
    public float maxRotationSpeed = 30f;   // Maksimum dönüþ hýzý
    private float rotationSpeed;           // Bu örneðe özel dönüþ hýzý

    void Start()
    {
        // Rastgele bir dönüþ hýzý atama
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        // Z ekseni etrafýnda dönüþ (2D oyunlarda genellikle bu ekseni kullanýrýz)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
