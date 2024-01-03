using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSB_knightmove : MonoBehaviour
{ 

    float vx;
    float vy;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity  = new Vector2(vx,vy);
        vx = 0f;
        vy = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vx = 4;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vx = -4;
        }if (Input.GetKey(KeyCode.UpArrow))
        {
            vy = 4;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vy = -4;
        }
    }
}
