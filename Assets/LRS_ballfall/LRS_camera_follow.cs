using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRS_camera_follow : MonoBehaviour
{
   //public GameObject ball;
    SpriteRenderer sr;
    Rigidbody2D brb;
    Rigidbody2D rb;
void Start ()
{
GameObject ball = GameObject.Find("you");
rb = GetComponent<Rigidbody2D>();
brb = ball.GetComponent<Rigidbody2D>();
sr = ball.GetComponent<SpriteRenderer>();
}
void Update ()
{
rb.velocity = new Vector2(0f, -4f);
    //transform.position = ball.transform.position;
if (sr.color == Color.red)
{
    rb.velocity = new Vector2(0f, -3f);
}

if (Input.GetKey(KeyCode.LeftArrow))
{
    rb.velocity = new Vector2(0f, -3f);
}
if (Input.GetKey(KeyCode.RightArrow))
{
    rb.velocity = new Vector2(0f, -3f);
}
}

}
