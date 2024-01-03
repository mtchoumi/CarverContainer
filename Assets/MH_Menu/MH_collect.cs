using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MH_collect : MonoBehaviour
{
    private Vector3 newPosY;
    public GameObject asteriod;
    public float time = 0.0f;
    public float interval = 5;
  public float limit;
  public float last;
  public float detection;
  public float detection1;
  bool check = true;
  private Vector3 playerpos;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        detection = transform.position.x - 0.1f;
        detection1 = transform.position.x + 0.1f;
        last = transform.position.y;
     
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "charIdle1a"){
            MH_Display.score++;
            Destroy(gameObject);
            
        }
        if(col.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "HazardAsteruid"){
             Destroy(gameObject);
        }
          if(col.gameObject.tag == "Enemy Projectiles"){
             Destroy(gameObject);
        }
    }

    // Update is called once per frame
   void Update()
    {
       playerpos = GameObject.Find("charIdle1a").transform.position;
       print(detection);
   float lastY = Mathf.Sin(Time.time * 5) * 0.5f + last;
 
  transform.position = new Vector2(transform.position.x,lastY);



    }
}
