using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject[] grass_prefabs;
    public GameObject[] tree_prefabs;
    public GameObject smoke_fx_prefab;
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
            AkSoundEngine.PostEvent("Play_Grass", gameObject);
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
            AkSoundEngine.PostEvent("Play_Change", gameObject);
            var tree_pref = tree_prefabs[Random.Range(0, tree_prefabs.Length)];
            GameObject tree = Instantiate(tree_pref, collision.transform.position, tree_pref.transform.rotation);
            Instantiate(smoke_fx_prefab, collision.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            ScoreManager.spawned_tree_count++;
            
        }
    }
}
