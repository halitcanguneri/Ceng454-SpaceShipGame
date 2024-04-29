using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // Oyuncunun ba�lang�� can de�eri

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("EnemyBullet"))  // E�er �arp���lan obje d��man mermisi ise
        {
            TakeDamage(1);  // Can� 1 azalt
        }
    }

    void TakeDamage(int damage)
    {
        FindObjectOfType<UIManager>().UpdatePlayerHealth(health);
        health -= damage;  // Gelen zarar kadar can� azalt
        if (health <= 0)
        {
            
            DeathScreen();  // Can 0'a ula�t���nda �l�m ekran�n� �a��r
        }
    }

    void DeathScreen()
    {
        Debug.Log("Player died!");
        FindObjectOfType<GameManager>().EndGame();

    }
}
