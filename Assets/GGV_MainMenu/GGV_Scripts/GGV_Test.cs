using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_Test : MonoBehaviour
{
    private bool search = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject c = GameObject.Find("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject c = GameObject.Find("Circle");
        if(search == true)
        {
            if(c.GetComponent<GGV_Bounce>().gameOver == true)
            {
                search = false;
                rb.velocity = new Vector2(-30, rb.velocity.y);
                Destroy(c);
            }
        }
    }
}
