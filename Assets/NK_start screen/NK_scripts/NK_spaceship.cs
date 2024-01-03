using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NK_spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public bool life;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject asteroid = GameObject.Find("asteroid 1");
        life = true; 
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, 0f); 
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.velocity = new Vector2(-8f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            rb.velocity = new Vector2(8f,0f);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0f,8f);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
        rb.velocity = new Vector2(0f,-8f);
        }
        anim.SetFloat("xvel",rb.velocity.x);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        SceneManager.LoadScene("NK_death screen");
    }
}