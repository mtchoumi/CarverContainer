using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_LifeLost : MonoBehaviour
{
    public static float lives = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(lives == 1f)
        {
            GameObject.Find("star1").GetComponent<SpriteRenderer>().color = Color.red;
        }

        if(lives == 2f)
        {
            GameObject.Find("star2").GetComponent<SpriteRenderer>().color = Color.red;
            GameObject.Find("star1").GetComponent<SpriteRenderer>().color = Color.red;

        }

        if(lives == 3f)
        {
            GameObject.Find("star3").GetComponent<SpriteRenderer>().color = Color.red;
            GameObject.Find("star2").GetComponent<SpriteRenderer>().color = Color.red;
            GameObject.Find("star1").GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "bomb")
        {
            AG_LifeLost.lives++;
        }

        if(lives == 1f)
        {
            GameObject.Find("heart3").GetComponent<SpriteRenderer>().color = Color.black;
            
        }

        if(lives == 2f)
        {
            GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = Color.black;

        }

        if(lives == 3f)
        {
            GameObject.Find("heart1").GetComponent<SpriteRenderer>().color = Color.black;
            SceneManager.LoadScene("AG_EndScene");
        }
    }
}
