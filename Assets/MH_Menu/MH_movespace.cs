using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_movespace : MonoBehaviour
{
    public Collider2D coll;
 public LayerMask Ground;
 public LayerMask Playertile;
  public Animator animator;
  private float moveInput;
  public float speed;
  private SpriteRenderer sr;
  private Rigidbody2D rb;
  public float jumpVelocity;

  public float dashTime = 0.0f;
  private float dashInterval = 0.5f;
public GameObject asteriod;
  public float delay;
  public float preventClick;
public bool isGrounded;
  public GameObject Tiles;
public Collider2D collider;
public float time = 0.0f;
private float JumpLimit;
public bool press = true;
public bool Ispress = true;

 bool click = true;
  bool pause = true;
  public bool check = true;
  public float one = 0;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        JumpLimit = transform.position.y + 1;
        isGrounded = coll.IsTouchingLayers(Ground);
    }
   


    // Update is called once per frame
      
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
         animator.SetFloat("speed",Mathf.Abs(moveInput));

    if(Input.GetKey("h") && Ispress == true){
        press = false;
      check = false;

       
    }
   
    /*if(Input.GetKeyUp("h")){
        press = true;
        check = true;
    
       one = 1;
       if(one == 1){
              pressClick++;
              one = 0;
       }
          if(pressClick >= 20){
            


        Ispress = false;
    }  
    
    }*/
    
    if(Ispress == false){
        time += Time.deltaTime;
        if(time >= 6){
            Ispress = true;
            time = 0.0f;
            //pressClick = 0;
        }
    }
    
    /*if(pressClick >= 15){
        time += Time.deltaTime;

        Ispress = false;
    }
    if(time <= 2.5){
        Ispress = true;
        pressClick = 0;
        time = 0.0f;
    }*/
       
        if(Input.GetKey("a") || Input.GetKey("d") && pause == true){
        speed -= Time.deltaTime;
      
        
        }else{
            speed += Time.deltaTime;
            
        
        }
          if(speed < 4.9f){
            speed = 5f;
            pause = false;
            speed += Time.deltaTime;
        }
       if(speed > 10){
           speed = 9.9f;
       }
        if(speed > 9){
            pause = true;
        }
         if(Input.GetKey("s")){
             delay = 3;
            if(click == true){
            dashTime += 6* Time.deltaTime;
            rb.velocity = new Vector2(90, rb.velocity.y);
            }
            if(sr.flipX == true){
                rb.velocity = new Vector2(-90, rb.velocity.y);
            }
           
            
            
            
            

            if(dashTime > dashInterval){
                dashTime = 0.0f;
                click = false;
               rb.velocity = new Vector2(speed, rb.velocity.y);

            } 

        }
        if(click == false){
            delay -= Time.deltaTime;
        }
        if(delay < 0){
            click = true;
        }

        if(rb.velocity.x < 0){
            sr.flipX = true;
             
        }
        if(rb.velocity.x > 0){
            sr.flipX = false;
             
        }
        if(transform.eulerAngles.z > 1){
            if(transform.eulerAngles.z > (360 - 1)){

            }else{
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
        if(Input.GetKey("space") && coll.IsTouchingLayers(Ground) && transform.position.y < 2){
            Jump();
        }else{
            if(transform.position.y > JumpLimit){
                animator.SetBool("isJumping",true);
            }else{
                animator.SetBool("isJumping",false);
            }
        }
        if(transform.position.y < -25.8){
            asteriod.GetComponent<MH_spawn>().isSpawning = false;
            print("tu");
        }
        if(coll.IsTouchingLayers(Playertile)){
            animator.SetBool("isJumping", false);
        }
     
    }
    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
    }
     
}
