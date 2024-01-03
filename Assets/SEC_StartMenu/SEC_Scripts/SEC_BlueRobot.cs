using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_BlueRobot : MonoBehaviour
{
    float direction;
    float stepsNum=0;
    float steps=0;
    public float moveSpeed;
    public GameObject bullet;
    float fireCooldown;
    public GameObject Item;
    public bool freezeRotation;
    public Sprite frontIdle;
    public Sprite backIdle;
    public bool notDummy;
    float startupTimer;
    bool go;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        startupTimer = 0;
        go = false;
        anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
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
            if (steps >= stepsNum)
            {
                //this triggers the robot to pick a new direction and number of steps to take
                anim.SetInteger("moveDir", 0);
                direction = Random.Range(0, 5);
                //1 is up, 2 is right, 3 is down, 4 is left
                stepsNum = Random.Range(1, 10);
                steps = 0;
            }
            else
            {
                if (direction == 1)
                {
                    transform.position += new Vector3(0, moveSpeed, 0);
                    anim.SetInteger("moveDir", 1);
                }
                else if (direction == 2)
                {
                    transform.position += new Vector3(moveSpeed, 0, 0);
                    anim.SetInteger("moveDir", 2);
                }
                else if (direction == 3)
                {
                    transform.position += new Vector3(0, -moveSpeed, 0);
                    anim.SetInteger("moveDir", 3);
                }
                else if (direction == 4)
                {
                    transform.position += new Vector3(-moveSpeed, 0, 0);
                    anim.SetInteger("moveDir", 4);
                }
                steps++;
            }
            //if(SEC_RobotAnim.stateName)

            //this part fires
            if (Random.Range(1, 75) <= 5 && fireCooldown >= 1 && notDummy)
            {
                GameObject newBullet = bullet;
                Vector2 newDir = (transform.position - new Vector3(GameObject.Find("Player").transform.position.x + Random.Range(-1 / 2, 1 / 2), GameObject.Find("Player").transform.position.y + Random.Range(-1 / 2, 1 / 2), 0));
                newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                newBullet.GetComponent<SpriteRenderer>().color = Color.blue;
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
            //steps = stepsNum;
        }
    }
}
