using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_Bounce : MonoBehaviour
{
    Rigidbody2D rb;
    private float vx;
    private float vy;
    private bool GoingDown;
    private bool CanDown;
    private bool bDelay; 
    public bool gameOver = false;
    private float deathTimer;
    private float V;
    Animator animator;
    static bool Hard;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CanDown = true;
        bDelay = false;
        V = 0.5f; 
        rb.constraints = RigidbodyConstraints2D.None;
    }

    
    void Update()
    {
        // if (static bool Hard == true)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, 100);
        // }
        vx = 0;
        //"W"ASD
        if(Input.GetKey(KeyCode.D))
        {
            vx = 7;
            rb.AddTorque(-V);
            
        }
        if(Input.GetKey(KeyCode.A))
        {
            vx = -7;
            rb.AddTorque(V);
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(CanDown == true)
            {
            vy = -20;
            GoingDown = true;
            CanDown = false;
            bDelay = true;
            }
            
        }else
        {
            GoingDown = false;
        }
        //Arrows
        if(Input.GetKey(KeyCode.RightArrow))
        {
            vx = 7;
            rb.AddTorque(-V);
            
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -7;
            rb.AddTorque(V);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(CanDown == true)
            {
            vy = -20;
            GoingDown = true;
            CanDown = false;
            bDelay = true;
            }
            
        }else
        {
            GoingDown = false;
        }
        //----------------------------------
        if (GoingDown == true)  
        {
            rb.velocity = new Vector2(vx, vy);
        }else
        {
            rb.velocity = new Vector2(vx, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Contains("Trampoline"))
        { 
            if(CanDown == false)
            {
                if(bDelay == false)
                {
                    CanDown = true;
                }
                bDelay = false;
                
            }
            GoingDown = false;
        }
            if(col.gameObject.name.Contains("Height"))
            {
                rb.velocity = new Vector2(rb.velocity.x, -3);
            }
    }
    void OnTriggerEnter2D(Collider2D tri)
    {
        if(tri.gameObject.name.Contains("Bullet"))
        {
            Destroy(tri.gameObject);
            rb.velocity = new Vector2(1f, 50f);
            vx = 20000f;
            gameOver = true;
            animator.SetBool("gameOver", true);
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameObject.Find("Trampoline").GetComponent<GGV_L>().work = true;
            
        }
        if(tri.gameObject.name.Contains("Laser"))
        {
            rb.velocity = new Vector2(1f, 50f);
            vx = 20000f;  
            gameOver = true;
            animator.SetBool("gameOver", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameObject.Find("Trampoline").GetComponent<GGV_L>().work = true;
        }
    }
}
