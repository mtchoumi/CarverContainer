using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MH_spawn : MonoBehaviour
{
 public LayerMask Ground;

 public LayerMask Playertile;
    private float AI;
    private float dice;
    public GameObject prefab;
    public float interval = 2;
    private float time = 0.0f;
   public bool isSpawning = true;
    public Vector2 hitY;
bool check = true;
   public LayerMask Generic;
    public Collider2D collider;
    private Rigidbody2D rb;
    private string sceneName;
    private float sceneCheck;
    public Sprite spriteTile;
    public static bool check1 = true;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentOne = SceneManager.GetActiveScene();
        Debug.Log(currentOne);
        string sceneName = currentOne.name;

    
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "charIdle1a"){
           
     //to do: switch from stirgn index to scene name
            SceneManager.LoadScene("MH_Death");
        
              Destroy(col.gameObject);
        
        }
        isSpawning = false;
         if(col.gameObject.name == "Tilemap"){
          
      

            
            
        } 


        if(collider.IsTouchingLayers(Ground)){
      
     
            Destroy(collider.gameObject);
        
       
        }
        if(collider.IsTouchingLayers(Generic)){

            Destroy(collider.gameObject);
        }
        if(collider.IsTouchingLayers(Playertile)){
            
     
            
check1 = false;
            
            Destroy(collider.gameObject);
        }
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
/*if(check == false){
    hitY = new Vector2(transform.position.x,-3);
}
        dice = Random.Range(-1f,1f);
        if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x > 0){

 AI = GameObject.Find("charIdle1a").transform.position.x - dice;
        }
              if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x < 0){

 AI = GameObject.Find("charIdle1a").transform.position.x + dice;
        }
       
        rb.velocity = new Vector2(0,-3 * 3);
        time += Time.deltaTime;
         if(time >= interval && isSpawning == true){
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(AI,8.92f),transform.rotation);
            time = 0f;
        }*/
        


    }
}
