using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float minRotationSpeed = -30f;  // Minimum d�n�� h�z�
    public float maxRotationSpeed = 30f;   // Maksimum d�n�� h�z�
    private float rotationSpeed;           // Bu �rne�e �zel d�n�� h�z�

    void Start()
    {
        // Rastgele bir d�n�� h�z� atama
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        // Z ekseni etraf�nda d�n�� (2D oyunlarda genellikle bu ekseni kullan�r�z)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
