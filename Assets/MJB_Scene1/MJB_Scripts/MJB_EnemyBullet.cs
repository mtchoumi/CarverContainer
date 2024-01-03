using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_EnemyBullet : MonoBehaviour
{
    GameObject Player;
    Vector3 playerPos;
    Vector3 dir;

    public float bulletSpeed;

    float timer;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerPos = Player.transform.position;

        timer = 0;

        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(11, 1);
    }

    // Update is called once per frame
    void Update()
    {

        if(timer < 0.4f)
        {
            playerPos = Player.transform.position;
            rb.velocity = (playerPos - transform.position).normalized * bulletSpeed * (Time.deltaTime + 1);
            dir = (playerPos - transform.position);
            //transform.position = Vector2.MoveTowards(transform.position, playerPos, bulletSpeed * Time.deltaTime);
        } else {
            rb.velocity = dir.normalized * bulletSpeed * (Time.deltaTime + 1);
        }

        

        timer += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            MJB_TimeScore.hits++;
        }
        if(col.collider.tag != "Enemy" && col.collider.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
}
