using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSD_Ball : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    private bool isDone = false;
    bool kicking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        GameObject arrow = GameObject.Find("arrow");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isDone = false;
            kicking = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            GetComponent<Transform>().position = new Vector2(12.045f,-6.16f);
            GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 70f);

         if (GetComponent<Transform>().position.y >= 7.5)
        {
            rb.velocity = new Vector2(0f, -70f);
        }
        if (GetComponent<Transform>().position.y <= -7)
        {
            rb.velocity = new Vector2(0f, 70f);
        }
        }
        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= 7.1 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= 11.04 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 1");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-8f, 5f);
                        kicking = true;
                    }
                }
            }

        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= 3.3 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= 7.09 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 2");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-9f, 5f);
                        kicking = true;
                    }
                }
            }

        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= 1.4 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= 3.2 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {             
                if (!isDone) 
                {
                    print("execute 3");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-12f, 5f);
                        kicking = true;
                    }
                }
            }

        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= -0.9 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= 1.3 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 4");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-17f, 5f);
                        kicking = true;
                    }
                }
            }

        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= -3 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= -1 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 5");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-12f, 5f);
                        kicking = true;
                    }
                }
            }

       if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= -7 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= -3.1 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 6");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-9f, 5f);
                        kicking = true;
                    }
                }
            }

        if(GameObject.Find("arrow").GetComponent<Transform>().position.y >= -10.9 && GameObject.Find("arrow").GetComponent<Transform>().position.y <= -7.1 && GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity == new Vector2(0f, 0f))
            {
                if (!isDone)
                {
                    print("execute 7");
                    isDone = true;
                    if(!kicking)
                    {
                        rb.velocity = new Vector2(-8f, 5f);
                        kicking = true;
                    }
                }
            }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "Square (1)")
        {
            isDone = false;
            kicking = false;
            GetComponent<Transform>().position = new Vector2(12.045f,-6.16f);
            GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 70f);

         if (GetComponent<Transform>().position.y >= 7.5)
        {
            rb.velocity = new Vector2(0f, -70f);
        }
        if (GetComponent<Transform>().position.y <= -7)
        {
            rb.velocity = new Vector2(0f, 70f);
        }
        }
        
    }
}