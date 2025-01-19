using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var obj  = Instantiate(bullet,transform.position,Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }
}
