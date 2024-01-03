using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSD_arrow : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(0f, 55f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {rb.velocity = new Vector2(0f, 0f);}
         if (GetComponent<Transform>().position.y >= 7.5)
        {
            rb.velocity = new Vector2(0f, -55f);
        }
        if (GetComponent<Transform>().position.y <= -7)
        {
            rb.velocity = new Vector2(0f, 55f);
        }
    }
}
