using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eml_enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 sidePosition;
    bool moveToSidePosition;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = new Vector2(0f,Random.Range(-12f,-3f));
        Physics2D.IgnoreLayerCollision(10,10,true);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-20f)
        {
            if(gameObject.name != "EnemyType1")
            {
                Destroy(gameObject);
            }
        }
        if(moveToSidePosition==true)
        {
            rb.velocity = new Vector2(0f, 0f);
            transform.position = Vector2.Lerp(transform.position, sidePosition, Time.deltaTime*2.5f);
            if(transform.position == sidePosition)
            {
                moveToSidePosition=false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        sidePosition = new Vector3(Mathf.Floor(eml_Spawner.enemiesHitListPosition%3f)-28f, -Mathf.Floor(eml_Spawner.enemiesHitListPosition/3f)+3.5f);
        gameObject.name = "enemy"+eml_Spawner.enemiesHitListPosition.ToString();
        eml_Spawner.enemiesHitListPosition++;
        moveToSidePosition = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
