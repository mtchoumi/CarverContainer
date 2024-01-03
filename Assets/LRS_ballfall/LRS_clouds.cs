using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRS_clouds : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
        rb.velocity = new Vector2 (-4f,0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == ("borderA"))
        {
            rb.velocity = new Vector2(4f,0f);
        }
         if (col.gameObject.name == ("borderB"))
        {
            rb.velocity = new Vector2(-4f,0f);
        }
    }
}
