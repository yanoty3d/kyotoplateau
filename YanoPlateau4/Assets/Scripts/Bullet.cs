using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; // Time before the bullet despawns

    void Start()
    {
        // Automatically destroy the bullet after a set lifetime
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when it hits a collider
        Destroy(gameObject);
    }
}
