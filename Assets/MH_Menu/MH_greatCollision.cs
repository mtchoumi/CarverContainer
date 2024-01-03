using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_greatCollision : MonoBehaviour
{
    bool isCollide = true;
    public Animator animatior;
    public LayerMask Ground;
    public float time = 0.0f;
private bool check = true;
private float BlastArea;
private float BlastAreaX;
 public LayerMask Playertile;
 private string sceneName;
 private Rigidbody2D rb;
public Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Scene currentOne = SceneManager.GetActiveScene();
        string sceneName = currentOne.name;
        
       BlastAreaX = transform.position.x + 5; 
         BlastArea = transform.position.x - 5; 
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "charIdle1a"){
            Destroy(collision.gameObject);
             SceneManager.LoadScene("MH_Death");
        }
      
        if(collider.IsTouchingLayers(Ground)){
            rb.bodyType = RigidbodyType2D.Static;
 GameObject.FindWithTag("Enemy Projectiles").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
           animatior.SetTrigger("Explode");
           Destroy(gameObject, 0.5f);
           
  
        
        }
       if(collider.IsTouchingLayers(Playertile)){

           Destroy(collider.gameObject, 1f);
           
  
        }
   
   
      
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles.z > 1){
            if(transform.eulerAngles.z > (360 - 1)){

            }else{
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
    
        
    }
}
