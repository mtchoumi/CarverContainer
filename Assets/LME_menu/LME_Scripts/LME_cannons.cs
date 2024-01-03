using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LME_cannons : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj = (GameObject)Instantiate(prefab,transform.position,transform.rotation);
            obj.GetComponent<Rigidbody2D>().AddForce(transform.up*6, ForceMode2D.Impulse);
        }
    }

    
}
