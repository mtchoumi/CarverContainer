using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEK1_Player_Movment : MonoBehaviour
{
Rigidbody2D rb; 
SpriteRenderer sr;
Animator anim;
bool ting;
    void Start()
    {
    ting = false;
    rb = GetComponent<Rigidbody2D>(); 
    sr = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();  
    }
    
    void Update(){
        if(ting == true) 
        {
            rb.velocity = new Vector2(9f, rb.velocity.y);
        } else
        {
        rb.velocity = new Vector2(7f, rb.velocity.y);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping",false);
            anim.SetBool("fall", true);
            GameObject.Find("Square").layer = 0;
        } else 
        {
        anim.SetBool("fall",false);
        }
    //MoveFowoard   
        //rb.velocity = new Vector2(0f, 0f);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    rb.velocity = new Vector2(-4f, rb.velocity.y);
        //}
        //if (Input.GetKey(KeyCode.RightArrow)) 
        //{ 
            //rb.velocity = new Vector2(4f, rb.velocity.y);
        //}

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x,5.5f);
            anim.SetBool("jumping",true);
            GameObject.Find("Square").GetComponent<ParticleSystem>().Play();

        }
        else{

            GameObject.Find("Square").GetComponent<ParticleSystem>().Stop();

        }
    }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.name == "Ting")
            {
                ting = true;
            
            }
        }   
}
