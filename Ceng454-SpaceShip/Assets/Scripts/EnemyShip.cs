using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    public GameObject bulletPrefab; // D��man gemisinin ate�leyece�i mermi prefab�
    public float fireRate = 2.0f; // Ate� etme h�z� (saniyede bir kez ate� eder)
    private float nextFireTime = 0f; // Sonraki ate� zaman�n� tutacak


    public float movementSpeed = 2.0f; // Geminin hareket h�z�
    public float movementDistance = 5.0f; // Gemi hareketinin maksimum mesafesi

    private float originalX; // Ba�lang�� X pozisyonu
    private bool movingRight = true; // Hareket y�n� kontrol�

    void Start()
    {
        
        originalX = transform.position.x; // Ba�lang�� X pozisyonunu kaydet
    }



    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireAtPlayer();
            nextFireTime = Time.time + fireRate; // Sonraki ate� i�in zaman� ayarla
        }
        // D��man gemisinin sa�a ve sola hareketi
        if (movingRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            if (transform.position.x >= originalX + movementDistance)
            {
                movingRight = false; // Hareket y�n�n� de�i�tir
            }
        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            if (transform.position.x <= originalX - movementDistance)
            {
                movingRight = true; // Hareket y�n�n� de�i�tir
            }
        }
    }
    private void FireAtPlayer()
    {
        Debug.Log("FireAtPlayer called");  // Fonksiyon �a�r�ld���nda log bas
        if (Time.time > nextFireTime)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Oyuncuyu bul
            if (player != null)
            {
                Vector3 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized; // Oyuncuya do�ru bir vekt�r hesapla
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Mermiyi d��man gemisinin konumunda olu�tur
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 6f; // Mermiye do�ru y�nde h�z ver
                Destroy(bullet, 5f); // Mermiyi 5 saniye sonra yok et
            }
            nextFireTime = Time.time + fireRate; // Sonraki ate� i�in zaman� ayarla
        }
    }
}
