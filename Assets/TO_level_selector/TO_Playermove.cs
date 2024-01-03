using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_Playermove : MonoBehaviour
{
    private int AnimTime = -1;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform t;
    public Animator animator;
    public GameObject net;
    float vy;
    float vx;
    float interval = 5;
    float time = 0.0f;
    public static bool crash = false;
    public static float shots = 0;
    public static float distancex;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
        net = GameObject.Find("net");
        vy = 30;
        vx = 5;
        print(crash);
        TO_NetShoot.miss = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimTime--;
        

        if(AnimTime == 0)
        {
            animator.SetBool("spacepress", false);
            AnimTime = -1;
        }
        time += Time.deltaTime;
        rb.velocity = new Vector2(vx,0f);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(vx,vy);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(vx,-vy);
        }
        if(crash == true)
        {
            vx = -10;
            print(crash);
        }
        if(time >= interval & crash == true)
        {
            crash = false;
            time = 0;
        }
        if(crash == false)
        {
            vx = 3;
            if(time >= interval)
            {
                vx = vx + 5;
                print(crash);
                time = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)&&shots<3)
        {
            GameObject obj = Instantiate(net, t.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(150f, 0f);
            shots++;
            animator.SetBool("spacepress", true);
            distancex = t.position.x;
            AnimTime = 30;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "rock_obstacle")
        {
            TO_health_script1.health = TO_health_script1.health - 1;
            crash = true;
        }
    }
}
