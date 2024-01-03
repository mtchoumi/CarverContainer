using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_PlayerMove : MonoBehaviour
{
    //[SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private Camera cam;
    Rigidbody2D rb;
    public float playerSpeed;
    public float playerSpeedOld;
    public GameObject Bullet;
    [SerializeField] private float bulletSpeed;

    public static int attackCharge;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpeedOld = playerSpeed;

        attackCharge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed * (Time.deltaTime + 1), Input.GetAxis("Vertical") * playerSpeed * (Time.deltaTime + 1));

        // \/ rotate towards mouse code \/
        Vector3 targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Input.GetMouseButtonDown(0))
        {
            // Vector3 aimDir = (targetPosition - transform.position).normalized;
            // angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;

            GameObject newBullet = MJB_ObjectPool.instance.GetPooledObject(); //Instantiate(Bullet, transform.position, Quaternion.Euler(0f,0f,angle));
            
            if(newBullet != null)
            {
                newBullet.transform.position = transform.position;
                newBullet.transform.rotation = Quaternion.Euler(0f,0f,angle);
                newBullet.SetActive(true);
            
                Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Transform>().up * bulletSpeed * (Time.deltaTime + 1);
            }
        }

        if(Input.GetMouseButtonDown(1) && attackCharge >= 5)
        {
            if(MJB_Canvas.tutorialDone == true)
            {
                GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            }

            for (int i = 0; i < 30; i++)
            {
                float random = Random.Range(0f, 360f);
                GameObject newMissile = Instantiate(Bullet, transform.position, Quaternion.Euler(0f, 0f, random));

                Physics2D.IgnoreCollision(newMissile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreLayerCollision(10, 10);

                newMissile.GetComponent<MJB_Bullet>().isMissile = true;
                newMissile.GetComponent<MJB_Bullet>().time = Random.Range(0.8f, 1.5f);
                newMissile.GetComponent<MJB_Bullet>().missleSpeed = Random.Range(2.5f, 7.5f);
                newMissile.GetComponent<MJB_Bullet>().random = Random.Range(-18f, 18f);
                newMissile.GetComponent<MJB_Bullet>().plusMinus = Random.Range(0,2);
            }
            for (int i = 1; i < 6; i++)
            {
                GameObject.Find("Main Camera").transform.GetChild(i).gameObject.SetActive(false);
            }
            attackCharge = 0;
            GameObject.Find("Main Camera").transform.GetChild(6).GetComponent<ParticleSystem>().Stop();
        }
    }
}