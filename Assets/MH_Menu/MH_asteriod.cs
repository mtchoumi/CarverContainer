using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MH_asteriod : MonoBehaviour
{
    public LayerMask Ground;
    private float AI;
    private float dice;
    private float AIy;

    public SpriteRenderer sr;
    public GameObject prefab;
    public float interval = 2;
    private float time = 0.0f;
  
    private int collider1;
    private int collider2;
    private float round;

    private float round2;
    public GameObject asteriod;
    public GameObject dM;
    public float time1 = 0.0f;
    public float interval1 = 10;
    public float StanceKill;
    public Collider2D collider;
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        asteriod.GetComponent<MH_spawn>().isSpawning = true;
   
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    /*public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "charIdle1a"){
            Destroy(col.gameObject);
            isSpawning = false;
        } 
         if(col.gameObject.name == "Tilemap"){
          
            Debug.Log(collider2);

            
            
        } 


        if(collider.IsTouchingLayers(Ground)){
       
            Destroy(collider.gameObject);
        
       
        }
        
    }*/


    // Update is called once per frame
   
    private void Update()
    {
        float lastNumber = 0;
        dice = Random.Range(-2,2);
        if(dice == lastNumber){
            dice = Random.Range(-2,2);
        }
        lastNumber = dice;

        StanceKill = Random.Range(-0.5f,1.5f);
        if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x > 0){
 
            AI = GameObject.Find("charIdle1a").transform.position.x - dice;
        }
        if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x < 0){

            AI = GameObject.Find("charIdle1a").transform.position.x + dice;
 
        }

        if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x == 0){
     
            AI = GameObject.Find("charIdle1a").transform.position.x - StanceKill;
            
        }
        if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.y > 0){
            AIy = GameObject.Find("charIdle1a").transform.position.y + 12;
    
        }
        rb.velocity = new Vector2(0,-3 * 3);
        time += Time.deltaTime;
        if(time >= interval && asteriod.GetComponent<MH_spawn>().isSpawning == true){
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(Mathf.RoundToInt(AI),AIy),transform.rotation);
            time = 0f;
            
        }

      
        
        


    }
}
