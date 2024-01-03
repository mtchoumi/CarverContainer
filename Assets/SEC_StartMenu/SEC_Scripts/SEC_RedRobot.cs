using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_RedRobot : MonoBehaviour
{
    public GameObject player;
    float direction;
    float stepsNum = 0;
    float steps = 0;
    public float moveSpeed;
    public GameObject bullet;
    float fireCooldown;
    public GameObject Item;
    public bool freezeRotation;
    public bool notDummy;
    Animator anim;
    bool go;
    float startupTimer;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        player = GameObject.Find("Player");
        startupTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startupTimer > 0.5)
        {
            go = true;
        }
        else startupTimer += Time.deltaTime;
        if (go)
        {
            float distanceDown = transform.position.y - player.transform.position.y;
            float distanceLeft = transform.position.x - player.transform.position.x;
            float distanceRight = player.transform.position.x - transform.position.x;
            float distanceUp = player.transform.position.y - transform.position.y;
            float distMax = Mathf.Max(distanceUp, distanceDown, distanceLeft, distanceRight);
            if (distMax == distanceUp)
            {
                transform.position += new Vector3(0, moveSpeed, 0);
                anim.SetInteger("moveDir", 1);
            }
            else if (distMax == distanceRight)
            {
                transform.position += new Vector3(moveSpeed, 0, 0);
                anim.SetInteger("moveDir", 2);
            }
            else if (distMax == distanceDown)
            {
                transform.position += new Vector3(0, -moveSpeed, 0);
                anim.SetInteger("moveDir", 3);
            }
            else if (distMax == distanceLeft)
            {
                transform.position += new Vector3(-moveSpeed, 0, 0);
                anim.SetInteger("moveDir", 4);
            }
            //this part fires
            if (Random.Range(1, 75) <= 5 && fireCooldown >= 1 && notDummy)
            {
                GameObject newBullet = bullet;
                Vector2 newDir = (transform.position - new Vector3(GameObject.Find("Player").transform.position.x + Random.Range(-1 / 2, 1 / 2), GameObject.Find("Player").transform.position.y + Random.Range(-1 / 2, 1 / 2), 0));
                newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<SpriteRenderer>().color = Color.red;
                //newBullet.GetComponent<Rigidbody2D>().velocity = -newDir;
                newBullet.transform.up = newDir;
                newBullet.GetComponent<Rigidbody2D>().AddForce(-newBullet.transform.up * 4, ForceMode2D.Impulse);
                fireCooldown = 0;
            }
            else fireCooldown += Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            steps = stepsNum;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}