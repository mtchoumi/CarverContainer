using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABS_coin : MonoBehaviour
{
    public float y;
    public float length;
    public float speed;
    public float starting;
    Rigidbody2D rb;
    public static float coins;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        coins = 0;
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, length)-length/2;
        transform.position = new Vector2(transform.position.x, starting + y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "player" && col.isTrigger == false)
        {
            Destroy (gameObject);
            coins += 1;
            print(coins);
            ABS_Display.score += 100;
        }
    }
}
