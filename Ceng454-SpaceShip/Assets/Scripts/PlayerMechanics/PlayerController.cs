using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Hareket hýzý
    public GameObject bulletPrefab; // Mermi prefab'ý
    public float fireRate = 1.0f; // Ateþ etme hýzý (saniyede bir kez)
    public Transform bulletSpawnPoint; // Mermi çýkýþ noktasý

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float nextFireTime = 0f; // Sonraki ateþ zamanýný tutacak

    void Start()
    {
        // Kamera sýnýrlarýný hesaplama
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // geminin yarým geniþliði
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // geminin yarým yüksekliði
    }

    void Update()
    {
        MovePlayer();
        HandleShooting();

        // Gemi sýnýrlar içinde kalýyor mu, kontrol et
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth),
            Mathf.Clamp(transform.position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight),
            0);
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
