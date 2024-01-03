using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSD_col : MonoBehaviour

{
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }         

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "Square (1)")
        {
            GetComponent<Transform>().position = new Vector2(12.045f,-6.16f);
            GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 80f);

        if (GameObject.Find("arrow").GetComponent<Transform>().position.y >= 6.98)
        {
            GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -40f);
        }
        if (GameObject.Find("arrow").GetComponent<Transform>().position.y <= -7.50)
        {
            GameObject.Find("arrow").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 40f);
        }
        }
    }


}
