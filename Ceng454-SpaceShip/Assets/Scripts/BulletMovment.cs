using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Mermi h�z�
    public float lifetime = 5f; // Mermi ya�am s�resi, saniye cinsinden

    void Start()
    {
        // Belirlenen ya�am s�resi sonunda mermiyi yok et
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Her frame'de mermiyi yukar� hareket ettir
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
