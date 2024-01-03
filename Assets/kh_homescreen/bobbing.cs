using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbing : MonoBehaviour
{
    public float amp;

    Rigidbody2D rb;

    //public GameObject battery = null;
    
    void Start()
    {
       // float vx = Random.Range(-6f, 3f);
         //rb.velocity = new Vector2(randposx,randomposy);
         Rigidbody2D rb = GetComponent<Rigidbody2D>();
         float vx = Random.Range(-9f,9f);
         float vy = Random.Range(-4,4f);
         rb.velocity = new Vector2(vx,vy);
         
        //float randomposy = Random.Range(-4f,4f);
    }
     void Update()
    {
        transform.position= new Vector3(0, Mathf.Sin(Time.time) * amp,0);
    }
}
