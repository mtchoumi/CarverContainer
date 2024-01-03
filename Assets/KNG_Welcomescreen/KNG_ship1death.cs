using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNG_ship1death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Contains("Bullet2"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}