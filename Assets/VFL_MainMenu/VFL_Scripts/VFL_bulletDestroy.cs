using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_bulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy Projectiles"))
        {
            Destroy(col.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D colTwo)
    {
        if (colTwo.collider.CompareTag("Player Projectiles"))
        {
            Destroy(colTwo.gameObject);
        }
    }
}
