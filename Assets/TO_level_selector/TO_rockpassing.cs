using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_rockpassing : MonoBehaviour
{
    Rigidbody2D rb;
    public float interval = 1;
    float time = 0.0f;
    public float sped = 0.0f;
    float vy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f,0f);
        vy = Random.Range(-55, 48);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval)
        {
            sped++;
            time = 0f;
        }
        if(sped==5||sped==9||sped==16||sped==20||sped==26||sped==29||sped==35||sped == 41||sped==45||sped==48||sped==60||sped==66||sped==74||sped==78||sped==84||sped==90)
        {
          rb.velocity = new Vector2(-130f,vy);  
          vy = Random.Range(-55, 48);          
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "outsidebarr")
        {
            transform.position = new Vector2(193, vy);
            rb.velocity = new Vector2(0f,0f);
        }
    }
}
