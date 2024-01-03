using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSB_dragon : MonoBehaviour
{    
  Rigidbody2D rb;
  float vx = 0f;
  public float interval = 0.5f;
  float time = 0.0f;
 //bool collide = false;
    Animator D_Animator;  
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
         D_Animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
       D_Animator.SetBool("hurt", false);
       if (Input.GetKeyDown(KeyCode.Space) && LSB_knightattack.collide == true && LSB_knightattack.swordpickup == true )
       {
         D_Animator.SetBool("hurt", true);
         }
       time += Time.deltaTime; //deltaTime is the time in seconds it took to complete last frame
      if (time >= interval)
      {
        rb.velocity  = new Vector2(vx,0);
        time = 0f;
        if (transform.position.x <= -7)
        {vx = Random.Range(0f,2f);
        print("trigger");}
        else if (transform.position.x >= 7)
        {vx = Random.Range(-2f,0f);
        print("trigger");}
        else
        {
          vx = Random.Range(-2f,2f);
        }
      }
    }
    //  void OnTriggerEnter2D(Collider2D trig)
    // {
    //   if (trig.gameObject.tag == "Player")
    //   {
    //   collide = true;
    //   print ("ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
    //   }
    // }
}
