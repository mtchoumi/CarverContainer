using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKCMove : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f,0f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-10f, 0f);
        }  
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(10f, 0f);
        }
    }
}
