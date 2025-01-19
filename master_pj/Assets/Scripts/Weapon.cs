using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform shootPoint;   // Reference to the position where bullets spawn
    public float bulletSpeed = 20f; // Speed of the bullet

    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            AkSoundEngine.PostEvent("Play_Shot", gameObject);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody rb = bullet.GetComponentInChildren<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("No Rigidbody found on bullet prefab!");
        }
    }

}
