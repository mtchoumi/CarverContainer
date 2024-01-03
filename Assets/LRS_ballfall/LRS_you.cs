using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LRS_you : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D crb;
    SpriteRenderer sr;
    Image sra;
    Image src;
    Image srd;
    SpriteRenderer sre;
    SpriteRenderer srf;
    SpriteRenderer srg;
    SpriteRenderer srh;
    public static float num;
    // Start is called before the first frame update
    void Start()
    {
     crb = GameObject.Find("Main Camera").GetComponent<Rigidbody2D>();
     rb = GetComponent<Rigidbody2D>();
     sr = GetComponent<SpriteRenderer>(); 
     sra = GameObject.Find("life 1").GetComponent<Image>();
     src = GameObject.Find("life 2").GetComponent<Image>();
     srd = GameObject.Find("life 3").GetComponent<Image>();
     sre = GameObject.Find("lvl 1 clouds").GetComponent<SpriteRenderer>();
     srf = GameObject.Find("lvl 2 bees").GetComponent<SpriteRenderer>();
     srg = GameObject.Find("lvl 3 birds").GetComponent<SpriteRenderer>();
     srh = GameObject.Find("lvl 4 city").GetComponent<SpriteRenderer>();
     var num = 0;
     Display.score = 0;
     sr.color = Color.green;
     sre.color = Color.clear;
     srf.color = Color.clear;
     srg.color = Color.clear;
     srh.color = Color.clear;
     print ("Avoid all obstacles, get coins, and fall to the end!");
    }

    // Update is called once per frame
    void Update()
    { 
      rb.velocity = new Vector2(0f,-4f);  
    /*  if (rb.velocity = new Vector2(0f,-3f))
      {
       crb = new Vector2(0f,-3f);
      }*/
      if (Input.GetKey(KeyCode.RightArrow))  
      {
         rb.velocity = new Vector2(8f,-3f);
      }
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        rb.velocity = new Vector2(-8f,-3f);
      }
       if (Input.GetKey(KeyCode.Q))
      {
        QuickPlay.nextScene();
      }
      /*if (Input.GetKey(KeyCode.R))
      {
      SceneManager.LoadScene("LRS_ballfall");
      }*/
    }
    void OnCollisionEnter2D (Collision2D col)
    {
       if(col.gameObject.name == ("lvl 1 clouds"))
      {
        print ("lvl 1 clouds");
        Destroy(GameObject.Find("lvl 1 clouds"));
      }
       if(col.gameObject.name == ("lvl 2 bees"))
      {
        print ("lvl 2 bees");
        Destroy(GameObject.Find("lvl 2 bees"));
      }
       if(col.gameObject.name == ("lvl 3 birds"))
      {
        print ("lvl 3 birds");
        Destroy(GameObject.Find("lvl 3 birds"));
      }
       if(col.gameObject.name == ("lvl 4 city"))
      {
        print ("lvl 4 city");
         Destroy(GameObject.Find("lvl 4 city"));
      }
      if (col.gameObject.name.Contains("coin"))
      {
        Display.score++;
      }
      if(col.gameObject.name.Contains("obsta"))
      {
      sr.color = Color.red;  
      }  
      if(col.gameObject.name == ("floor"))
      {
        SceneManager.LoadScene("LRS_YOUWON");
        print ("hooray");
       
      }
    }
   
    void OnCollisionExit2D(Collision2D col)
    {
      if(col.gameObject.name.Contains("obsta"))
      {
        print ("f");
        num ++;
        if (num == 1)
        {
          sra.color = Color.black;
          sr.color = Color.green;
        }
        if (num == 2)
        {
          src.color = Color.black;
          sr.color = Color.green;
        }
        if (num == 3)
        {
          srd.color = Color.black;
          sr.color = Color.green;
          SceneManager.LoadScene("LRS_gameover");
          print ("good job, you died.");
        }
      }
    }
}
