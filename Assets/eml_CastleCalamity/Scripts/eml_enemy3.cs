using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eml_enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody2D rb;
    bool shoot = false;
    Vector3 sidePosition;
    bool moveToSidePosition = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        rb.velocity = new Vector2(0f, Random.Range(-3f,-2f));
        Physics2D.IgnoreLayerCollision(10,10,true);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<3f && shoot==false && gameObject.name != "EnemyType3")
        {
            rb.velocity = player.transform.position - transform.position;
            shoot = true;
            transform.rotation = transform.rotation;
        }
        if(transform.position.y>3f)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle+90f, Vector3.forward), Time.deltaTime*10f);
        }
        if(transform.position.y<-20f)
        {
            if(gameObject.name != "EnemyType3")
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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        print("hey");
        moveToSidePosition = true;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        rb.velocity = new Vector2(0f, 0f);
        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
