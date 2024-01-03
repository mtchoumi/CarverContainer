using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifes : MonoBehaviour
{
    SpriteRenderer srb;
    /*Image sr;
    Image src;
    Image srd;
    public static float num;*/
    // Start is called before the first frame update
    void Start()
    {
        GameObject ball = GameObject.Find("you");
        srb = ball.GetComponent<SpriteRenderer>(); 
        /*sr = GameObject.Find("life 1").GetComponent<Image>();
        src = GameObject.Find("life 2").GetComponent<Image>();
        srd = GameObject.Find("life 3").GetComponent<Image>();
        var num = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (srb.color == Color.red)
        {
            if (num == 0)
            {
            sr.color = Color.black;
            srb.color = Color.green;
            }
        } 
        if (sr.color == Color.black)
        {
            num = 1;
        }
        if (srb.color == Color.red)
        {
            if (num == 1)
            {
            src.color = Color.black;
            srb.color = Color.green;
            }
        }
        if (src.color == Color.black)
        {
            num = 2;
        }
        if (srb.color == Color.red)
        {
            print ("pee");
            if (num == 2)
            {
               // print ("pee");
            srd.color = Color.black;
            srb.color = Color.green;
            }
        } 
        if (srd.color == Color.black)
        {
            num = 3;
        }*/
    }
}
