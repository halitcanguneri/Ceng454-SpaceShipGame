using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35; // Bu mermi tarafýndan verilecek zarar miktarý
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy")) // Eðer çarpýþýlan obje düþman gemisi ise
        {
            WaveManager waveManager = FindObjectOfType<WaveManager>();
            waveManager.OnEnemyDestroyed();
            Destroy(hitInfo.gameObject); // Düþman gemisini yok et
            Destroy(gameObject); // Mermiyi yok et
            
        }
    }
}

