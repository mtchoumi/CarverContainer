using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SEP_Scene3Main : MonoBehaviour
{
    private float timer4 = 0f;
    private float interval3 = 2.5f;   
    Rigidbody2D rb;
    private int direction = 0;
    public float movespeed = 0.5f;
    public int score1;
    private float timer5 = 0f;
    SpriteRenderer sr;
    [SerializeField] private Sprite Sprite1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SEP_MenuScript.stageNum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer5 += Time.deltaTime;
        if(SEP_BowlColliderTest.level == 1)
        {
            movespeed+= 2;
            SEP_BowlColliderTest.level = 3;
            SEP_BowlColliderTest.canKeyPress = true;
        }
        if(SEP_BowlColliderTest.level == 2)
        {
            movespeed = 7;
            SEP_BowlColliderTest.level = 4;
            SEP_BowlColliderTest.canKeyPress = true;
        }
        if(direction == 0)
        {
            if(timer4 <= interval3)
            {
                rb.velocity = new Vector2(-2f * movespeed, 0);
                timer4 = 0f;
            }
            
        }
        if(direction == 1)
        {
            if(timer4 <= interval3)
            {
                rb.velocity = new Vector2(2f * movespeed,0);
                timer4 = 0f;
            }
            
        }
        if(rb.position.x < -6.9f)
        {
            direction = 1;
        }
        if(rb.position.x > 6.9f)
        {
            direction = 0;
        }
        if(timer5 > 9f)
        {
            SEP_MenuScript.stageNum = 3;
            SceneManager.LoadScene("SEP_MenuScene");
        }
    }
}
