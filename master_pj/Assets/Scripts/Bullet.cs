using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject[] grass_prefabs;
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
            var grass_pref = grass_prefabs[Random.Range(0, grass_prefabs.Length)];
            Instantiate(grass_pref,transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreManager.spawned_grassed_count++;
        }
        else if (collision.gameObject.CompareTag("Building"))
        {

        }
        else if (collision.gameObject.CompareTag("Car"))
        {
            var appearence_on_hit = collision.gameObject.GetComponent<ChangeAppearanceOnHit>();
            appearence_on_hit.TransformToTree();
            Destroy(gameObject);
            ScoreManager.spawned_tree_count++;
        }
    }
}
