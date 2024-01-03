using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class soo_playermove : MonoBehaviour
{
    public KeyCode Key;
     private float timer;
 
    Rigidbody2D rb; //Declares a variable to hold the paddles RigidBody2D
    SpriteRenderer sr; //Declares a variable to hold the paddles SpriteRenderer
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Sets rb to the RigidBody2D of the paddle
        sr = GetComponent<SpriteRenderer>(); //Set sr to the SpriteRenderer of the paddle 
           }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, 0f); //sets the velocity of the paddle to 0.
        if (Input.GetKey(KeyCode.LeftArrow))  //checks if the leftarrow is pressed
        {
            rb.velocity = new Vector2(-3f, 0f); //sets the paddle velocity to -4 in the x direction
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(3f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f, 3f);
        }                                         
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(0f, -3f);
        }
    }
    void OnCollisionEnter2D(Collision2D col) //col is the object it collides with
    {
        if(col.collider.CompareTag("knight")) //checks if the object it collides with is the ball
        {
            print (col.collider.tag);
                Destroy(col.gameObject); 
              soo_spawn.count -= 1;
        }
    }
    }
