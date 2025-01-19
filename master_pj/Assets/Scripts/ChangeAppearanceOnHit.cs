using UnityEngine;

public class ChangeAppearanceOnHit : MonoBehaviour
{
    public GameObject[] treePrefab;   // The tree prefab to switch to
    public GameObject smoke_fx_prefab;

    private bool hasTransformed = false; // Prevents multiple transformations

    public void TransformToTree()
    {
        if (hasTransformed)
        {
            return;
        }
        // Mark as transformed
        hasTransformed = true;

        var tree_pref = treePrefab[Random.Range(0, treePrefab.Length)];
        GameObject tree = Instantiate(tree_pref, transform.position, tree_pref.transform.rotation);
        Instantiate(smoke_fx_prefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
