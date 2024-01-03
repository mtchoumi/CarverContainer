using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LDG_PlayMovement : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer sr;
    private Animator anim;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
        GameObject hail = GameObject.Find("LDG_HailArt");  //Sets the variable ball to the ball GameObject
        hail.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 3f); //Sets the velocity of the ball to Vx = 2 and Vy = 2 
         anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.A)) 
        {
            rb.velocity = new Vector2(-10f, 0f);
            sr.flipX = true;
            anim.SetBool("IsRunning", true);
        }
       else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(10f, 0f);
            sr.flipX = false;
            anim.SetBool("IsRunning", true);
        }     
        else 
        {
        anim.SetBool("IsRunning", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "LDG_HailArt" || col.gameObject.name == "LDG_HailArt(Clone)")  //Checks if object collides with the floor
        {
        LDG_Display2.score--; 
        }
            
    }     
}