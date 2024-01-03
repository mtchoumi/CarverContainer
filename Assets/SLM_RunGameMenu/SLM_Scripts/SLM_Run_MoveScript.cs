using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLM_Run_MoveScript : MonoBehaviour
{
    public float moveSpeed;
    SpriteRenderer sprite;
    [SerializeField] private Sprite leftCar;
    [SerializeField] private Sprite rightCar;
   // float time;
   // private bool boost = false;
   // private Rigidbody2D rb;
//private Animator animation;
    // Start is called before the first frame update
    void Start()
    {
      //  animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
      //  rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
       
       // Vector3 lastPos = new Vector3(transform.position.x,transform.position.y,0);
        transform.position += new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0).normalized*Time.deltaTime*moveSpeed;
       // print(rb.velocity);
       // Vector3 presentPos = transform.position += new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0)*Time.deltaTime*moveSpeed;
       //wip
       /*
        if(lastPos!=presentPos){
            GetComponent<RightViewWalking_0>().moving = true;
        }
        */
        
        if(Input.GetKey(KeyCode.LeftShift)&&Input.GetKey(KeyCode.RightShift)){
            moveSpeed = moveSpeed*2;
           //time += Time.deltaTime;
        
        }
        
        
        if(Input.GetKey(KeyCode.A)||Input.GetKey("left")){
            sprite.sprite = leftCar;
           // print("I went left");
        }
        if(Input.GetKey(KeyCode.D)||Input.GetKey("right")){
            sprite.sprite = rightCar;
          //  print("I went right");
        }
    }
}
