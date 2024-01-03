using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_PlayerMove : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite PlayerBackIdle;
    public Sprite PlayerFrontIdle;
    [SerializeField] float moveSpeed;
    public GameObject bullet;
    public GameObject bulletB;
    float fireCooldown;
    public float bulletSpeed;
    public bool demo;
    bool dual;
    bool tri;
    bool octo;
    bool rapid;
    bool bouncy;
    bool invul;
    float invulTimer;
    public float hits;
    static public string itemHeld = "Empty";
    bool held;
    float dTimer = 0;
    float tTimer = 0;
    float oTimer = 0;
    float rTimer = 0;
    float hori;
    float vert;
    Animator anim;
    public bool freezeRotation;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().freezeRotation=true;
        fireCooldown = 0;
        dual = false;
        tri = false;
        octo = false;
        rapid = false;
        if(demo==false) transform.position = new Vector3(Random.Range(-1f, 1f) * 9, Random.Range(-45 / 10, 25 / 10), 0);
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        anim.SetInteger("moveDir", 0);
        if (hori > 0.25f&&transform.position.x<8.7f) { transform.position += new Vector3(moveSpeed, 0, 0); anim.SetInteger("moveDir", 2); }
        else if(hori<-0.25f&&transform.position.x>-8.7f) { transform.position += new Vector3(-1*moveSpeed, 0, 0); anim.SetInteger("moveDir", 4); }
        if (vert > 0.25f&&transform.position.y<2.5f) { transform.position += new Vector3(0, moveSpeed, 0); anim.SetInteger("moveDir", 1); }
        else if(vert<-0.25f&&transform.position.y>-3.8f){ transform.position += new Vector3(0, -1 * moveSpeed, 0); anim.SetInteger("moveDir", 3); }
        if (Input.GetAxis("Fire1") != 0 && fireCooldown >= 0.5f)
        {
            Fire();
        }
        else fireCooldown+=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)&&itemHeld!="Empty")
        {
            useItem();
        }
        if (dTimer > 0)
        {
            dTimer += -Time.deltaTime;
        }
        else
        {
            dual = false;
        }
        if (tTimer > 0)
        {
            tTimer += -Time.deltaTime;
        }
        else
        {
            tri = false;
            
        }
        if (oTimer > 0)
        {
            oTimer += -Time.deltaTime;
        }
        else
        {
            octo = false;
        }
        if (rTimer > 0)
        {
            rTimer += -Time.deltaTime;
        }
        else
        {
            rapid = false;
        }
        if (invulTimer > 0)
        {
            invulTimer += -Time.deltaTime;
        }
        else
        {
            invul = false;
            sr.color = Color.white;
        }
    }
    /*public isPositive(float num)
    {
        if (num > 0)
        {
            return true; 
        }else return false;
    }*/
    void Fire()
    {
        GameObject newBullet = bullet;
        Vector2 newDir = (transform.position - GameObject.Find("Crosshair").transform.position);
        newBullet = Instantiate(newBullet, transform.position, Quaternion.identity);
        newBullet.transform.up = newDir;
        newBullet.GetComponent<Rigidbody2D>().AddForce(-newBullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
        Quaternion b1Rotation = newBullet.transform.rotation;
        if (octo)
        {
            for (var i = 1; i < 9; i++)
            {
                newBullet = Instantiate(newBullet, transform.position, b1Rotation);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z - (45 * i));
                newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
                if (tri == true)
                {
                    newBullet = Instantiate(newBullet, transform.position, Quaternion.identity);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z - 5-(45*i));
                    newBullet.GetComponent<Rigidbody2D>().AddForce((-newBullet.transform.up) * bulletSpeed, ForceMode2D.Impulse);
                    newBullet = Instantiate(newBullet, transform.position, b1Rotation);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z + 5-(45*i));
                    newBullet.GetComponent<Rigidbody2D>().AddForce((-newBullet.transform.up) * bulletSpeed, ForceMode2D.Impulse);
                }
            }
        }else if (dual)
        {
            newBullet = Instantiate(newBullet, transform.position, Quaternion.identity);
            newBullet.transform.up = -newDir;
            newBullet.GetComponent<Rigidbody2D>().AddForce(-newBullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
        }else if (tri == true)
        {
            newBullet = Instantiate(newBullet, transform.position, Quaternion.identity);
            newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z - 5);
            newBullet.GetComponent<Rigidbody2D>().AddForce((-newBullet.transform.up) * bulletSpeed, ForceMode2D.Impulse);
            newBullet = Instantiate(newBullet, transform.position, b1Rotation);
            newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z + 5);
            newBullet.GetComponent<Rigidbody2D>().AddForce((-newBullet.transform.up) * bulletSpeed, ForceMode2D.Impulse);
            if (dual == true)
            {
                newBullet = Instantiate(newBullet, transform.position, b1Rotation);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z - 5);
                newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
                newBullet = Instantiate(newBullet, transform.position, b1Rotation);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, b1Rotation.eulerAngles.z + 5);
                newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
            }
        }
        if (rapid) { fireCooldown = 0.4f; } else fireCooldown = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Projectiles") && invul == false)
        {
            SEC_Reticle.health--;
            invul = true;
            invulTimer = 1;
            sr.color = Color.magenta;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    void useItem()
    {
        if (itemHeld != "Empty")
        {
            if (itemHeld == "Dual") {
                dual = true;
                dTimer = 5;
            }
            if (itemHeld == "Tri") { 
                tri = true;
                tTimer = 5;
            }
            if (itemHeld == "Octo") {
                octo = true;
                oTimer = 5;
            }
            if (itemHeld == "Rapid") {
                rapid = true;
                rTimer = 5;
            }
            itemHeld = "Empty";
        }
    }
}
