using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LSB_knightattack : MonoBehaviour
{
    public static bool collide = false;
    float dragonlives = 3f;
    Animator m_Animator;
    public static bool swordpickup = false;
    Transform tra;
    public GameObject prefab = null;
    // Start is called before the first frame update
    void Start()
    {
      dragonlives = 1f; 
      collide = false; 
      m_Animator = gameObject.GetComponent<Animator>();
      tra = gameObject.GetComponent<Transform>();
      GameObject.Find("Text").GetComponent<Text>().text= "arrowkeys to pick up sword";   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collide == true && swordpickup == true )
        {
            dragonlives++;
            //collide = false;
            print("atat");
            transform.position = new Vector2(0.0f, -4f);
            GameObject obj1 = (GameObject)Instantiate(prefab,new Vector2 (0f,3.8f),transform.rotation);
            obj1.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,1f), Random.Range(0,1f), Random.Range(0,1f),1f);
            GameObject.Find("Text").GetComponent<Text>().text="Dragons: "+Mathf.FloorToInt(dragonlives);


        }
        // if (dragonlives == 0f)
        // {
        //     SceneManager.LoadScene("LSB_menu");
        // }
        if (collide == true)
        {
            m_Animator.SetBool("collide", true);
        }
        if (collide == false)
        {
            m_Animator.SetBool("collide", false);
        }       
        // if (swordpickup == true)
        // {

        // }
    }
    void OnTriggerEnter2D (Collider2D trig)
    {
        if(trig.gameObject.tag == "Pickup"){
            swordpickup = true;
            Destroy(GameObject.Find("sword"));
            m_Animator.SetBool("swordpickup", true);
            m_Animator.SetBool("collide", false); 
            GameObject.Find("Text").GetComponent<Text>().text="space to attack";           
            
        }
        else// if (trig.gameObject.tag == "Dragon")
        {
         collide = true;
         print("hi");
        }
    }
    void OnTriggerExit2D()
    {
        collide = false;
        print("hello");
    }
   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Projectiles")
         {
         SceneManager.LoadScene("LSB_menu");
         print("col");           
         }  
    }
//    void OnTriggerEnter2D(Collision2D trig)
//   {
//        if(trig.gameObject.tag == "Pickup"){
//           swordpickup = true;
//        }
//   }
}
