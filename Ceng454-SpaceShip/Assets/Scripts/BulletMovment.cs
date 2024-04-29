using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Mermi hýzý
    public float lifetime = 5f; // Mermi yaþam süresi, saniye cinsinden

    void Start()
    {
        // Belirlenen yaþam süresi sonunda mermiyi yok et
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Her frame'de mermiyi yukarý hareket ettir
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
