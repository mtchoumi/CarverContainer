using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TO_fishmove : MonoBehaviour
{
    Rigidbody2D rb;
    float vy;
    float vx;
//    public float interval = 3;
//    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vy = Random.Range(35f,65f);
        vx = 0;
        rb.velocity = new Vector2(0f,vy);
        TO_Playermove.crash = false;
    }
        
    // Update is called once per frame
    void Update()
    {

    }       
    void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.name.Contains("barrier"))
        {
            vy = Random.Range(35f,65f);
            rb.velocity = new Vector2(vx,-vy);
        }
        if(other.gameObject.name.Contains("barrieraswell"))
        {
            vy = Random.Range(35f,65f);
            rb.velocity = new Vector2(vx,vy);
        }
        if(other.gameObject.name.Contains("net"))
        {
            SceneManager.LoadScene("TO_game_win");
        }
    }

}
