using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_RobotSpawn : MonoBehaviour
{
    public GameObject blueR;
    public GameObject redR;
    public GameObject grayR;
    [SerializeField] float xMultRange;
    [SerializeField] float yMultRange;
    public GameObject player;
    CircleCollider2D circ;
    BoxCollider2D box;
    bool isTouching;
    float startupCooldown;
    // Start is called before the first frame update
    void Start()
    {
        startupCooldown = 0;
        player = GameObject.Find("Player");
        circ = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;
        if (collisionName == "Player" || collisionName.Contains("InsideWall") || collisionName.Contains("pBullet"))
        {
            isTrue = true;
        }
        else isTrue = false;
    }*/

    void Update()
    {
        startupCooldown += Time.deltaTime;
        //isTouching = circ.IsTouchingLayers(LayerMask("Player"));
        transform.position = new Vector3(Random.Range(-1f, 1f) * xMultRange, Random.Range(-45 / 10, 25 / 10) * yMultRange, 0);
        isTouching = false;
        if (circ.IsTouchingLayers(LayerMask.GetMask("Player"))/*|| box.IsTouchingLayers(LayerMask.GetMask("Ground"))*/)
        {
            isTouching = true;
        }
        //notTouching = false;
        //notTouching = isTrue;
        // if (notTouching == false)
        //if ((transform.position.x - player.transform.position.x > 4 || transform.position.x - player.transform.position.x < 4) && (transform.position.y - player.transform.position.y > 4 || transform.position.y - player.transform.position.y < 4))
        if (isTouching == false&&startupCooldown>2)
        {
            float newRand = Random.Range(1, 150);
            if (newRand == 3)
            {
                Instantiate(blueR, transform.position, Quaternion.identity);
            }
            if (newRand == 11)
            {
                Instantiate(redR, transform.position, Quaternion.identity);
            }
            if (newRand == 42)
            {
                Instantiate(grayR, transform.position, Quaternion.identity);
            }
        }
    }
}