using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_BounceBulletDestroy : MonoBehaviour
{
    GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Button = GameObject.Find("DamageButton")
        Physics2D.IgnoreCollision(Button.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
        */
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player Projectiles"))
        {
            Destroy(gameObject);
        }
    }
}
