using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow)) //checks if the leftarrow is pressed
        {
         rb.velocity = new Vector2(-5f, 0f); //sets the paddle velocity to -4 in the x direction
        }
         if (Input.GetKey(KeyCode.RightArrow))
        { 
        rb.velocity = new Vector2(5f, 0f);
         }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f, 5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -5f);
        }
    }
}
