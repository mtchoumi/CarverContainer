using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABS_bouncepad : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float alsomove;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        alsomove = 0.5f;
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x,alsomove);
    }


    void OnTriggerEnter2D(Collider2D col)
     {
        if (col.gameObject.name.Contains("bouncedetector"))
        {
            alsomove = -alsomove;
        }
     }
}
