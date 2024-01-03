using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEC_Bullet : MonoBehaviour
{
    GameObject player;
    public GameObject Item;
    float bounces;
    CircleCollider2D circ;
    SpriteRenderer sr;
    bool bouncy;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        Physics2D.IgnoreLayerCollision(10, 10);
        circ = GetComponent<CircleCollider2D>();
        bounces = 0;
        bouncy = false;
        if (sr.color == Color.yellow) bouncy = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Break();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.name.Contains("Blue")) { SEC_Reticle.score += 400; } 
            else if (collision.gameObject.name.Contains("Red")) { SEC_Reticle.score += 800; }
            else if (collision.gameObject.name.Contains("Yellow")) { SEC_Reticle.score += 1400; }
            GameObject newItem = Item;
            newItem = Instantiate(Item, transform.position, Quaternion.identity);
            //print("spawned");
            /*if (newRand <= 3 || newRand >= 29 || newRand == 11||newRand==21)
            {
                GameObject newItem = Item;
                newItem = Instantiate(Item, transform.position, Quaternion.identity);
                if (newRand <= 3)
                {
                    newItem.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (newRand >= 29)
                {
                    newItem.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else if (newRand == 11)
                {
                    newItem.GetComponent<SpriteRenderer>().color = Color.yellow;
                }else if (newRand == 27)
                {
                    //newItem.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else newItem.GetComponent<SpriteRenderer>().color = Color.magenta;
            }*/
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (bouncy == false || bounces > 3)
            {
                Destroy(gameObject);
            }
            else bounces++;
        }
    }
}
