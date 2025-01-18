using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var hit_obj = GetComponent<CarObject>();
        if (!hit_obj) { return; }

        hit_obj.OnDead();
    }
}
