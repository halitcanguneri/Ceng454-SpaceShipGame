using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Hareket h�z�
    public GameObject bulletPrefab; // Mermi prefab'�
    public float fireRate = 1.0f; // Ate� etme h�z� (saniyede bir kez)
    public Transform bulletSpawnPoint; // Mermi ��k�� noktas�

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float nextFireTime = 0f; // Sonraki ate� zaman�n� tutacak

    void Start()
    {
        // Kamera s�n�rlar�n� hesaplama
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // geminin yar�m geni�li�i
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // geminin yar�m y�ksekli�i
    }

    void Update()
    {
        MovePlayer();
        HandleShooting();

        // Gemi s�n�rlar i�inde kal�yor mu, kontrol et
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
