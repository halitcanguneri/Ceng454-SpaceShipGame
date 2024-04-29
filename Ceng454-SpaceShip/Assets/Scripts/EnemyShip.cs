using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    public GameObject bulletPrefab; // Düþman gemisinin ateþleyeceði mermi prefabý
    public float fireRate = 2.0f; // Ateþ etme hýzý (saniyede bir kez ateþ eder)
    private float nextFireTime = 0f; // Sonraki ateþ zamanýný tutacak


    public float movementSpeed = 2.0f; // Geminin hareket hýzý
    public float movementDistance = 5.0f; // Gemi hareketinin maksimum mesafesi

    private float originalX; // Baþlangýç X pozisyonu
    private bool movingRight = true; // Hareket yönü kontrolü

    void Start()
    {
        
        originalX = transform.position.x; // Baþlangýç X pozisyonunu kaydet
    }



    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireAtPlayer();
            nextFireTime = Time.time + fireRate; // Sonraki ateþ için zamaný ayarla
        }
        // Düþman gemisinin saða ve sola hareketi
        if (movingRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            if (transform.position.x >= originalX + movementDistance)
            {
                movingRight = false; // Hareket yönünü deðiþtir
            }
        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            if (transform.position.x <= originalX - movementDistance)
            {
                movingRight = true; // Hareket yönünü deðiþtir
            }
        }
    }
    private void FireAtPlayer()
    {
        Debug.Log("FireAtPlayer called");  // Fonksiyon çaðrýldýðýnda log bas
        if (Time.time > nextFireTime)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); // Oyuncuyu bul
            if (player != null)
            {
                Vector3 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized; // Oyuncuya doðru bir vektör hesapla
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Mermiyi düþman gemisinin konumunda oluþtur
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 6f; // Mermiye doðru yönde hýz ver
                Destroy(bullet, 5f); // Mermiyi 5 saniye sonra yok et
            }
            nextFireTime = Time.time + fireRate; // Sonraki ateþ için zamaný ayarla
        }
    }
}
