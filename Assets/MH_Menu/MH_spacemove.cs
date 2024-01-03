using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_spacemove : MonoBehaviour
{
    // Start is called before the first frame update
  public Animator animator;
    public float speed;
    private float moveInput;

    public float jumpVelocity;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(speed * moveInput, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput));
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
        if(Input.GetKey("space")){
            Jump();
        }
    }
    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity * Time.fixedDeltaTime);
    }


}
