using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_CharacterMove : MonoBehaviour
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
        rb.velocity = new Vector2(0f, 0f); //sets the velocity of the paddle to 0.
        if (Input.GetKey(KeyCode.LeftArrow))  //checks if the leftarrow is pressed
        {
            rb.velocity = new Vector2(-4f, 0f); //sets the paddle velocity to -4 in the x direction
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(4f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))  //checks if the leftarrow is pressed
        {
            rb.velocity = new Vector2(0f, 4f); //sets the paddle velocity to -4 in the x direction
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -4f);
        }
    }
}
