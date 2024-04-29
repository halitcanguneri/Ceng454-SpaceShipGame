using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // Oyuncunun baþlangýç can deðeri

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("EnemyBullet"))  // Eðer çarpýþýlan obje düþman mermisi ise
        {
            TakeDamage(1);  // Caný 1 azalt
        }
    }

    void TakeDamage(int damage)
    {
        FindObjectOfType<UIManager>().UpdatePlayerHealth(health);
        health -= damage;  // Gelen zarar kadar caný azalt
        if (health <= 0)
        {
            
            DeathScreen();  // Can 0'a ulaþtýðýnda ölüm ekranýný çaðýr
        }
    }

    void DeathScreen()
    {
        Debug.Log("Player died!");
        FindObjectOfType<GameManager>().EndGame();

    }
}
