using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_Bullet : MonoBehaviour
{
    float timer;

    // bool colorChange = false;

    public bool isMissile = false;
    public float missleSpeed;
    public float random;
    public float time;
    public int plusMinus;

    [SerializeField] private GameObject MissileExplosion;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Physics2D.IgnoreLayerCollision(10, 0);
        
        if(plusMinus == 1)
        {
            random += 50;
        } else {
            random -= 50;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMissile == true)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * missleSpeed * (Time.deltaTime + 1);
            transform.Rotate(0, 0, random * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= 1.5f && isMissile == false)
        {
            gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true); //GetComponent<TrailRenderer>().enabled = true;
            timer = 0;
        }

        // if(MJB_Canvas.map == true && colorChange == false)
        // {
        //     GetComponent<SpriteRenderer>().color = new Color(0.2524475f, 0.3648653f, 0.8773585f, 1); //og color is 415EE0
        //     colorChange = true;
        // }

        if(isMissile == true && timer >= time)
        {
            Destroy(gameObject);
            if(isMissile == true)
            {
                Instantiate(MissileExplosion, transform.position, Quaternion.identity);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(isMissile == false)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false); //GetComponent<TrailRenderer>().enabled = false;
        } else {
            Destroy(gameObject);
            if(isMissile == true)
            {
                Instantiate(MissileExplosion, transform.position, Quaternion.identity);
            }
        }  
    }
}
