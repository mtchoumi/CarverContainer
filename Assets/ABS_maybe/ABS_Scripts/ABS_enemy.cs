using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABS_enemy: MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float move;
    Animator anim;
    public bool isAlive;
    float deathtimer;
    BoxCollider2D collider1;
    [SerializeField]AnimationClip deathclip;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        move = 0.5f;
        anim = GetComponent<Animator>();
        anim.SetBool("life",true);
        isAlive=true;
        collider1 = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(move,rb.velocity.y);
        if (isAlive == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            collider1.enabled = false;
            deathtimer -= Time.deltaTime;
            if (deathtimer<0)
            {
                Destroy(gameObject);
            }
        }
    }

     void OnTriggerEnter2D(Collider2D col)
     {
        if (col.gameObject.name.Contains("detector"))
        {
            move = -move;
        }

        
     }

     void OnTriggerStay2D(Collider2D col)
     {
        if (col.gameObject.name.Contains("player") && isAlive)
            {
                anim.SetBool("life",false);
                isAlive=false;
                ABS_Display.score+=50f;
                deathtimer = deathclip.length; 
            }
    }
}
