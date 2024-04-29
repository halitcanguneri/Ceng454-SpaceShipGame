using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 35; // Bu mermi taraf�ndan verilecek zarar miktar�
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy")) // E�er �arp���lan obje d��man gemisi ise
        {
            WaveManager waveManager = FindObjectOfType<WaveManager>();
            waveManager.OnEnemyDestroyed();
            Destroy(hitInfo.gameObject); // D��man gemisini yok et
            Destroy(gameObject); // Mermiyi yok et
            
        }
    }
}

