using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ABS_player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public bool alive;
    public GameObject enemy;
    public static float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        alive = true;
        timer = 30;
    }
 
    void Update()
    {
        if (alive == false)
        {
            print ("y tf wont u work then");
        }
        anim.SetFloat("XVel", rb.velocity.x);
        if(Input.GetKey(KeyCode.R))
        {
            if(ABS_startportal.iwastoldtokeepworking == true)
            {
                SceneManager.LoadScene("ABS_yes");
                ABS_coin.coins = 0;
                ABS_Display.score = 0;
            }
        }

        if (alive==true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-4f,rb.velocity.y);
                sr.flipX=true;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(4f,rb.velocity.y);
                sr.flipX=false;
            }
            if (ABS_startportal.iwastoldtokeepworking == true)
            {
                timer -= Time.deltaTime;
                if(timer < 0)
                {
                    alive = false;
                }
            }
        }

        if (alive == false)
        {
            anim.SetBool ("PlayerAlive", false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2 (0, 0);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (alive==true)
        {
            if (col.gameObject.name.Contains("floor"))
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
                {
                    rb.velocity = new Vector2(rb.velocity.x,5f);
                }
            } 
        }
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("enemy") && col.gameObject.GetComponent<ABS_enemy>().isAlive)
        {
            alive = false;
        }

        if (col.gameObject.name=="bouncepad")
        {
            rb.velocity = new Vector2(rb.velocity.x, 10.5f);
        }
    }

}
//SceneManager.LoadScene("ABS_no");