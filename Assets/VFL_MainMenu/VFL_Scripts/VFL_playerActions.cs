using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_playerActions : MonoBehaviour
{
    //subtract point B (mouse) from point A (transform.position of the)
    //Use normalize function to make magnitude 1
    Vector3 mousePosition;
    //private float stunTimer = 0.1f;
    public GameObject bulletPrefab;
    public float moveSpeed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, 0f);
        Vector3 point = new Vector3();
        mousePosition = Input.mousePosition;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed * Time.deltaTime;
        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        point.z = 0;
        if(Input.GetButtonDown("Fire1")){
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Physics2D.IgnoreCollision(newBullet.GetComponent<PolygonCollider2D>(), GetComponent<PolygonCollider2D>());
                newBullet.GetComponent<Rigidbody2D>().AddForce((point - transform.position) * 3, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy Projectiles"))
        {
            VFL_PlayerHealthDisplay.playerHealth -= 20;
            /*
            stunTimer += Time.deltaTime;
            if(stunTimer > 0f){
                moveSpeed = 0;
                if(stunTimer > 2f){
                    moveSpeed = 6;
                }
            }
            */
            
        }
        if(col.CompareTag("Bounce Projectile"))
        {
            VFL_PlayerHealthDisplay.playerHealth -= 50;
            VFL_HealthDisplay.bossHealth += 45;
        }
        if(col.CompareTag("Buttons")){
            VFL_HealthDisplay.bossHealth -= 50;
            Destroy(col.gameObject);
        }
        if(col.CompareTag("Health Potion"))
        {
            VFL_PlayerHealthDisplay.playerHealth += 70;
            Destroy(col.gameObject);
        }
    }
}