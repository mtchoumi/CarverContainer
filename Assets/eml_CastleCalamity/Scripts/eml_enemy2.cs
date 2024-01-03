using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eml_enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    float originalX;
    int direction;
    Rigidbody2D rb;
    Vector3 sidePosition;
    bool moveSideToSide = true;
    bool moveToSidePosition = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalX = transform.position.x;
        Physics2D.IgnoreLayerCollision(10,10,true);
        transform.position = new Vector2(transform.position.x, 7.5f);
        if(Random.Range(0,2)==0)
        {
            rb.velocity = new Vector2(2f, -5f);
            animator.SetInteger("LookingDirection", 1);
        }
        else
        {
            rb.velocity = new Vector2(-2f, -5f);
            animator.SetInteger("LookingDirection", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(moveSideToSide)
        {    
            if(transform.position.x>(originalX+1.5))
            {
                rb.velocity = new Vector2(-2f, rb.velocity.y);
                animator.SetInteger("LookingDirection", 0);
            }
            if(transform.position.x<(originalX-1.5))
            {
                rb.velocity = new Vector2(2f, rb.velocity.y);
                animator.SetInteger("LookingDirection", 1);
            }
            if(transform.position.y<-20f)
            {
                if(gameObject.name != "EnemyType2")
                {
                    Destroy(gameObject);
                }
            }
        }
        if(moveToSidePosition==true)
        {
            animator.SetInteger("LookingDirection", 2);
            rb.velocity = new Vector2(0f, 0f);
            transform.position = Vector2.Lerp(transform.position, sidePosition, Time.deltaTime*2.5f);
            if(transform.position == sidePosition)
            {
                moveToSidePosition=false;
            }       
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetInteger("LookingDirection", 2);
        moveSideToSide = false;
        gameObject.name = "enemy"+eml_Spawner.enemiesHitListPosition.ToString();
        sidePosition = new Vector3(Mathf.Floor(eml_Spawner.enemiesHitListPosition%3f)-28f, -Mathf.Floor(eml_Spawner.enemiesHitListPosition/3f)+3.5f);
        eml_Spawner.enemiesHitListPosition++;
        moveToSidePosition = true;
        rb.velocity = new Vector2(0f, 0f);
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
