using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SEP_BowlColliderTest : MonoBehaviour
{
    
    public static bool canKeyPress = true;
    public static int level = 0;
    public Sprite BowlSprite1;
    public Sprite BowlSprite2;
    public Sprite BowlSprite3;
    SpriteRenderer sr;
    public static float timer7 = 0f;
    private float reninterval= 1.5f; 
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canKeyPress == true)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(level == 0)
                {
                    canKeyPress = false;
                    level++;
                    SEP_MenuScript.starNum = 1;
                }
                if (level == 3)
                {
                    sr.sprite = BowlSprite2;
                    level = 2;
                    canKeyPress = false;
                    SEP_MenuScript.starNum = 2;
                }
                if(level == 4)
                {
                    level++;
                    SEP_MenuScript.starNum = 3;
                }
            }  
        }
        if(timer7 >= reninterval)
        {
            SceneManager.LoadScene("SEP_MenuScene");
        }
        if(level == 1)
        {
            sr.sprite = BowlSprite1;
        }
    }
    /*void OnTriggerStay2D(Collider2D other)
    {
       
        //Debug.Log("collision");
       
    }
    void OnTriggerExit2D(Collider2D other)
    {
       
    } */
}
