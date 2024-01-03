using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_BigEnemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;

    Vector2 playerPos = new Vector2();

    public bool isAffected;
    float timer;
    int damage;
    float attackTimer;
    bool attackReset;
    // Start is called before the first frame update
    void Start()
    {
        isAffected = false;
        timer = 0;
        damage = 0;

        attackTimer = 0;
        attackReset = true;

        if(MJB_Canvas.map == true)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.2196078f, 0.427451f, 0.3411765f, 1); //og color is FAD7D1 2nd color is 386D57
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
        if(playerPos.x < transform.position.x + 55 && playerPos.x > transform.position.x - 55 && isAffected == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);

            Vector3 targetPosition = GameObject.Find("Player").transform.position;
            Vector3 dir = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        if(isAffected == true)
        {
            timer += Time.deltaTime;
            if(timer >= 0.7f)
            {
                isAffected = false;
                timer = 0;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }
        }

        attackTimer += Time.deltaTime;
        if(attackTimer >= 0.8 && attackReset == true && isAffected == false)
        {
            enemySpeed += 6;
            Physics2D.IgnoreLayerCollision(4, 9, true);
            Physics2D.IgnoreLayerCollision(4, 0, true);

            attackReset = false;
        }
        if(attackTimer >= 1.1 && attackReset == false)
        {
            attackTimer = 0;
            enemySpeed -= 6;
            Physics2D.IgnoreLayerCollision(4, 9, false);
            Physics2D.IgnoreLayerCollision(4, 0, false);

            attackReset = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            MJB_TimeScore.hits++;
            Destroy(gameObject);
        }
        if(col.gameObject.name == "Bullet(Clone)")
        {
            damage++;
            //setting velocity back to zero so the enemy's movement isn't affected by being hit by the bullet;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;

            if(damage == 3)
            {
                Destroy(gameObject);
                MJB_TimeScore.score++;
                MJB_PlayerMove.attackCharge++;
                for(int i = 0; i < 6; i++)
                {
                    if(MJB_PlayerMove.attackCharge >= i)
                    {
                        GameObject.Find("Main Camera").transform.GetChild(i).gameObject.SetActive(true);
                        if(MJB_Canvas.map == true)
                        {
                            GameObject.Find("Main Camera").transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0.2078431f, 0.2627451f, 0.7843137f); //3543C8
                        }
                    }
                }
                if(MJB_PlayerMove.attackCharge >= 5)
                {
                    GameObject.Find("Main Camera").transform.GetChild(6).GetComponent<ParticleSystem>().Play();
                    if(MJB_Canvas.map == true)
                    {
                        ParticleSystem ps = GameObject.Find("Main Camera").transform.GetChild(6).GetComponent<ParticleSystem>();
                        ParticleSystem.MainModule ma = ps.main;
                        ma.startColor = new Color(0.2078431f, 0.2627451f, 0.7843137f);
                    }
                }
            }
        }
    }
}
