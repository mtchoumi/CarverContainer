using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CK_PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public static float jumpHeight;
    private float speed;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CK_Display.gTime = 30f;
        rb = GetComponent<Rigidbody2D>();  
        speed = 8;
        jumpHeight = 9f;
        player.transform.position = new Vector2(Random.Range(-7.4f, 7.33f), 0f);
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        CK_Display.gTime -= Time.deltaTime;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed;
        if(CK_Display.gTime <= 1f)
        {
            CK_DisplayScore.UpdateScores(CK_Display.score);
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.score = 0;
        }
    //Powerups - Ice Cube, Spring, Heart, lava, fake ball, spikes. "Spikes are on CK_BallScript.cs".
        
    //Player Controls
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            //anim.isJumping = true;
            //if(player.rb.velocity.y == 0)
            //{
                //isJumping = false;
            //}
            print(jumpHeight);
        } 
        if(Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector2(2.5f * Input.GetAxis("Horizontal"), 0);
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("ballFake"))
        {
            CK_DisplayScore.UpdateScores(CK_Display.score);
            Destroy(GameObject.Find("player"));
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.lives = 1;
            CK_Display.score = 0;
        }
        if(other.gameObject.CompareTag("spikes"))
        {
            CK_DisplayScore.UpdateScores(CK_Display.score);
            Destroy(GameObject.Find("player"));
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.lives = 1;
            CK_Display.score = 0;
        }
    }   
}
