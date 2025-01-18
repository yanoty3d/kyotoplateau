using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObject : MonoBehaviour
{
    public GameObject tree_prefab;

    public void OnDead()
    {
        Destroy(gameObject);
        Instantiate(tree_prefab,transform.position, tree_prefab.transform.rotation);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnDead();
        }
    }
}
