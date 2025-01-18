using UnityEngine;

public class ChangeAppearanceOnHit : MonoBehaviour
{
    public GameObject treePrefab;   // The tree prefab to switch to
    public GameObject carObject;   // The current car object to be replaced

    private bool hasTransformed = false; // Prevents multiple transformations

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is caused by a bullet
        if (collision.gameObject.CompareTag("Bullet") && !hasTransformed)
        {
            TransformToTree();
        }
    }

    void TransformToTree()
    {
        // Mark as transformed
        hasTransformed = true;

        // Replace the car object with the tree prefab
        if (treePrefab != null && carObject != null)
        {
            // Instantiate the tree at the car's position and rotation
            GameObject tree = Instantiate(treePrefab, carObject.transform.position, carObject.transform.rotation);

            // Optionally, set the tree as a child of the same parent
            tree.transform.parent = carObject.transform.parent;

            // Destroy the car object
            Destroy(carObject);
        }
        else
        {
            Debug.LogWarning("Tree prefab or car object is not assigned!");
        }
    }
}
