using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_SpecialEnemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;

    Vector2 playerPos = new Vector2();

    public bool isAffected;
    float timer;
    int damage;
    float attackTimer;

    [SerializeField] private GameObject Bullet;

    [SerializeField] private GameObject Portal;

    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        isAffected = false;
        timer = 0;
        damage = 0;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
        if(playerPos.x < transform.position.x + 55 && playerPos.x > transform.position.x - 55 && isAffected == false && transform.position.x > playerPos.x + 3 || transform.position.x < playerPos.x - 3 || transform.position.y > playerPos.y + 3 || transform.position.y < playerPos.y - 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
            Vector3 targetPosition = GameObject.Find("Player").transform.position;
            Vector3 dir = (targetPosition - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

        } else if(isAffected == false && transform.position.x < playerPos.x + 3 || transform.position.x > playerPos.x - 3 && transform.position.y < playerPos.y + 3 || transform.position.y > playerPos.y - 3) {
            transform.position = Vector2.MoveTowards(transform.position, -playerPos, enemySpeed * Time.deltaTime);

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
        if (attackTimer >= 0.8f)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            attackTimer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Bullet(Clone)")
        {
            damage++;
            //setting velocity back to zero so the enemy's movement isn't affected by being hit by the bullet;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;

            if(MJB_Canvas.map == false)
            {
                if(damage == 7)
                {
                    if(MJB_Canvas.map == false && isDead == false)
                    {
                        Instantiate(Portal, transform.position, Quaternion.identity);
                        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.GetChild(3).transform.position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y + 2, 0);
                        isDead = true;
                    }
                    Destroy(gameObject);
                    MJB_TimeScore.score++;
                    MJB_PlayerMove.attackCharge += 3;
                }
            } else if(damage == 5) {
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
