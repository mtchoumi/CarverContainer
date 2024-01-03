using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_AcidSplash : MonoBehaviour
{
        private string sceneName;
    public LayerMask Ground;
    private SpriteRenderer sr;
    public Collider2D collider;
    public bool check = true;
    public Vector2 contactpoint;
         public LayerMask Playertile;
    // Start is called before the first frame update
    void Start()
    {
          Scene currentOne = SceneManager.GetActiveScene();
        string sceneName = currentOne.name;
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
       
    }
   void OnCollisionEnter2D(Collision2D collision){
       if(collision.gameObject.name == "charIdle1a"){
           SceneManager.LoadScene("MH_Death");
            Destroy(collision.gameObject);
        }
        
        if(collider.IsTouchingLayers(Ground)){
            Destroy(gameObject);
            check = false;
            print(check);
        }
         if(collision.gameObject.name == "Tilemap"){
          contactpoint = collision.GetContact(0).point;
            Destroy(gameObject);
        }
        if(collider.IsTouchingLayers(Playertile)){

           Destroy(collider.gameObject, 1f);
           
  
        }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
