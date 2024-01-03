using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SLM_Run_KillerFollowScript : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer killerSprite;
    [SerializeField] private float moveSpeed;
    private float time = 0f;
    [SerializeField]private Sprite leftCar;
    [SerializeField]private Sprite rightCar;
    //private SLM_DisplayScore ScoreScript;
 //   private float deltaTime = 0f;
    //private Rigidbody2D rb;
    //private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
       // player = GameObject.Find("Player");
       player = GameObject.Find("Player");
       killerSprite = GetComponent<SpriteRenderer>();
      // ScoreScript = GameObject.Find("Text").GetComponent<SLM_DisplayScore>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetDir = player.transform.position - transform.position;
        targetDir.Normalize();
        transform.position += new Vector3(targetDir.x, targetDir.y) * moveSpeed * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("SLM_RunGame");
        }
        if(player.transform.position.x<transform.position.x){
            killerSprite.sprite = leftCar;
        }
        if(player.transform.position.x>transform.position.x){
            killerSprite.sprite = rightCar;
        }
        /*
        time += Time.deltaTime;
        if(time>1){
            time = 0;
        }
        */
        /*
        if(ScoreScript.score==20){
            moveSpeed= moveSpeed + 1f;
            print("I increase");
        }
        if(ScoreScript.score==10){
            moveSpeed= moveSpeed + 1f;
        }
        */
     /*
        deltaTime += Time.deltaTime;
        if(deltaTime==7){
            moveSpeed+=1;
            deltaTime=0;
        }
        */

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Player"){
            //Destroy(col.gameObject);
          //  GameObject.Find("Player").GetComponent<SLM_Run_MoveScript>().moveSpeed = GameObject.Find("Player").GetComponent<SLM_Run_MoveScript>().moveSpeed*2;
            /*
            if(time>1){
            SceneManager.LoadScene("SLM_RunGameOver");
        }
        */
        SceneManager.LoadScene("SLM_RunGameOver");
        }
    }
    void OnCollisionStay2D(Collision2D col){
      //  print(" I COLLDIES");
        if(col.gameObject.name.Contains("Tree")){
            time++;
         //   print("I hit a tree");
            if(time>100){
                Destroy(col.gameObject);
                moveSpeed += 0.2f;
            //    print("I destroyed the tree");
                time = 0;
            }
        }
       // print("I set time to 0");
      //  time = 0;
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.name.Contains("Tree")){
            time = 0;
        }
    }
    /*
    void DestroyTree(){
    float time = 0f;
    time += Time.deltaTime;
    if(time>3){
        Destroy();
    }

}
*/
}  
 
