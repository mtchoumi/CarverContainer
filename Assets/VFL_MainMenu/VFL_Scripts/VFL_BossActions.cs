using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_BossActions : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0.1f;
    private float shootTimer = 0.1f;
    private float bounceBulletTimer = 0.1f;
    //private float superBulletTimer = 0.1f;
    //private bool isShooting;
    GameObject Player;
    public GameObject bossBulletprefab;
    public GameObject bounceBulletprefab;
    //public GameObject superBossBullet;
    //GameObject warningCircle;
    Vector2 movementVector = Vector2.zero;
    public float bossMoveSpeed;
    Rigidbody2D bossRB;

    // Start is called before the first frame update
    void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("player");
       // warningCircle = GameObject.Find("warningCircle");
        //isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal") * bossMoveSpeed;
        movementVector.y = Input.GetAxis("Vertical") * bossMoveSpeed;
    }
    void FixedUpdate()
    {
        //superBulletTimer += Time.deltaTime;
        bounceBulletTimer += Time.deltaTime;
        timer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        //shootTimer += Time.deltaTime;
        if (timer > 0.0f)
        {
            shootInterval();
            bounceBallShootInterval();
            //superBulletInterval();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player Projectiles"))
        {
            Destroy(col.gameObject);
        }
    }
    void shootInterval()
    {
        if (shootTimer > 0.0f)
        {
            if (shootTimer > 0.2f && shootTimer < 0.5f)
            {
                bossShoot();
                shootTimer = 0.0f;
            }
        }
    }
    void bounceBallShootInterval()
    {
        if (bounceBulletTimer > 0.0f)
        {
            if (bounceBulletTimer > 2.7f && bounceBulletTimer < 3f)
            {
                bossBounceBulletShoot();
                bounceBulletTimer = 0.0f;
            }
        }
    }
    /*
    void superBulletInterval()
    {
        if(superBulletTimer > 0.0f)
        {
            if(superBulletTimer > 5.5f && superBulletTimer < 7f)
            {
                superBulletShoot();
                superBulletTimer = 0.0f;
            }
        }
    }
    */
    void bossBounceBulletShoot()
    {
        GameObject newBounceBullets = Instantiate(bounceBulletprefab, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newBounceBullets.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
        newBounceBullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 8, ForceMode2D.Impulse);
    }
    void bossShoot()
    {
        GameObject newBossBullets = Instantiate(bossBulletprefab, transform.position, Quaternion.identity);
        newBossBullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f)).normalized * 8, ForceMode2D.Impulse);
    }
    /*
    void superBulletShoot()
    {
        GameObject newSuperBullets = Instantiate(superBossBullet, transform.position, Quaternion.identity);
        newSuperBullets.GetComponent<Rigidbody2D>().AddForce(warningCircle.transform.position, ForceMode2D.Impulse);
    }
    */
}
