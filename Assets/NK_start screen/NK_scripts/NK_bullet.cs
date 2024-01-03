using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(obj.GetComponent<PolygonCollider2D>(),gameObject.GetComponent<PolygonCollider2D>());
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(20f,0f);
        }

    }
    // void OnCollisionEnter2d(Collision2D col)
    // {
    //     if(col.gameObject.CompareTag("Enemy")){
    //         Destroy(gameObject);
    //         Destroy(col.gameObject);
    //     }
        
    // }
}