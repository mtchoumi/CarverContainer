using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_BulletMove : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tra;
    private float time1;
    private float interval1 = 5f;
    private bool Decision = true;
    private float time3 = 0.0f;
    private float interval3 = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        tra = GetComponent<Transform>();
        
        rb = GetComponent<Rigidbody2D>();

        //below time so bullet destroys offscreen, doesn't lag
        time1 = 0.0f;
        

        // GameObject c = GameObject.Find("Circle");
        // Summon s = c.GetComponent<GGV_Summon>();

        Decision = true;

    // Vector3 characterScale = transform.localScale;

        if(tra.position.x < 0)
        {
         transform.position = new Vector2(transform.position.x - 20, transform.position.y);
         transform.localScale = new Vector3(-2, 2, 1);
        //  transform.localScale.x = -2;
           
        } else if (tra.position.x > 0)
        {
        transform.position = new Vector2(transform.position.x + 20, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject w = GameObject.Find("xLimit Right");
        GGV_TimeDisplay t = w.GetComponent<GGV_TimeDisplay>();

        time3 += Time.deltaTime;
        if(time3 >= interval3)
        {
            if(Decision == true)
            {
           if(tra.position.x < 0.00f)
           {
               rb.velocity = new Vector2(30f, 0f);
               
           } else if (tra.position.x > 0)
           {
               rb.velocity = new Vector2(-30f, 0f);
           }
           Decision = false;
           time3 = 0.0f;
        }
        }
        time1 += Time.deltaTime;
        if(time1 >= interval1)
        {
            Destroy(gameObject);
        }
        if(t.hasWon == true)
        {
            Destroy(gameObject);
        }
    }
}
