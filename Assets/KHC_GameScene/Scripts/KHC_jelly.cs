using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KHC_jelly : MonoBehaviour
{
    public float movementSpeed = 30;
    [HideInInspector] public float speedRange = 20;

    static int jelCount = 0;
    public const int minJelly = 8;
    const int maxJelly = KHC_move.maxJelly;
    public GameObject jelly;
    private Rigidbody2D rb;
    private Rigidbody2D killer;
    bool dead = false;

    [HideInInspector] public float riverMinX;
    [HideInInspector] public float riverMaxX;
    [HideInInspector] public float riverMinY;
    [HideInInspector] public float riverMaxY;
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (rb.velocity.x, Random.Range(-1 * speedRange / 2, speedRange / 2));
        speedRange = movementSpeed - 10;
        jelCount++;

        Rigidbody2D river = GameObject.Find("river").GetComponent<Rigidbody2D>();
        float midWidth = transform.localScale.y / 2;
        float midHeight = transform.localScale.y / 2;

        riverMinX = - river.transform.localScale.x / 2 + midWidth;
        riverMaxX = river.transform.localScale.x / 2 - midWidth;
        riverMinY = river.transform.position.y - river.transform.localScale.y / 2 + midHeight;
        riverMaxY = river.transform.position.y + river.transform.localScale.y / 2 - midHeight;

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("river").GetComponent<Collider2D>(), true);

    }

    void Update()
    {

        rb.velocity = new Vector2 (-1 * (Random.Range(-1 * speedRange, speedRange) + movementSpeed), rb.velocity.y);
        if (transform.position.x < riverMinX && !dead) 
        {
            transform.position = new Vector2(riverMaxX, Random.Range(riverMinY, riverMaxY));
            // int ranum = Random.Range(1, minJelly / 4);
            // if (ranum > 1 && jelCount < maxJelly)
            // {
            //     ranum = Random.Range(1, minJelly / 4);
            //     for (int i = 0; i < ranum; i++) 
            //     {
            //         GameObject newJelly = Instantiate(jelly, new Vector2(riverMaxX - Random.Range(0, speedRange), Random.Range(riverMinY, riverMaxY)), Quaternion.identity);
            //         newJelly.GetComponent<Rigidbody2D>().velocity = new Vector2 (rb.velocity.x, Random.Range(-1 * speedRange, speedRange));
            //     }
            // }
        }

        // else if (transform.position.x < riverMinX && dead)  Destroy(this.gameObject, 0.0f);

        // if (transform.position.y < riverMinY || transform.position.y > riverMaxY) 
        // {
        //     GetComponent<Collider2D>().enabled = true;
        //     GetComponent<Rigidbody2D>().isKinematic = false;
        //     dead = false;
        //     killer = null;
        // }

        // if (killer && !killer.GetComponent<KHC_jelly>().dead && dead)
        // {            
        //     transform.position = Vector2.MoveTowards(transform.position, killer.transform.position, movementSpeed * Time.deltaTime);
        //     if (Mathf.Abs(transform.position.y - killer.transform.position.y) < 1 && Mathf.Abs(transform.position.x - killer.transform.position.x) < 1)
        //     {
        //         Destroy(this.gameObject, 0.0f);
        //     }
        // }

    }

    // void OnCollisionEnter2D (Collision2D col)
    // {

    //     Rigidbody2D bumprb = col.gameObject.GetComponent<Rigidbody2D>();
    //     int ranum = Random.Range(1, minJelly / 2);

    //     if (col.gameObject.tag == "jel" && bumprb.transform.position.x < transform.position.x && ranum > 1)
    //     {
    //         KHC_jelly snack = col.gameObject.GetComponent<KHC_jelly>();
    //         snack.killer = this.gameObject.GetComponent<Rigidbody2D>();
    //         snack.GetComponent<Collider2D>().enabled = false;
    //         snack.GetComponent<Rigidbody2D>().isKinematic = true;
    //         snack.GetComponent<Rigidbody2D>().velocity = rb.velocity / 2;
    //         snack.dead = true;
    //     }

    // }
    
}
