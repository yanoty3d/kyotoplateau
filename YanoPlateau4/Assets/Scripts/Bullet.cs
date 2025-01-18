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
        if (collision.gameObject.CompareTag("Floor"))
        {

        }
        else if (collision.gameObject.CompareTag("Building"))
        {

        }
        else if (collision.gameObject.CompareTag("Car"))
        {
            var appearence_on_hit = collision.gameObject.GetComponent<ChangeAppearanceOnHit>();
            appearence_on_hit.TransformToTree();
            Destroy(gameObject);
        }
    }
}
