using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CK_PowerUpScript: MonoBehaviour
{
    public GameObject heart;
    public GameObject spring;
    public GameObject spikes;
    public GameObject ballClone;
    public GameObject iceCube;
    public GameObject ball;
    private float speed;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("ball");
        iceCube = GameObject.Find("iceCube");
        ballClone = GameObject.Find("ballClone");
        spring = GameObject.Find("spring");
        heart = GameObject.Find("Heart");
        spikes = GameObject.Find("spikes");
        timer = 0f;
        heart.SetActive(false);
        spring.SetActive(false);
        spikes.SetActive(false);
        ballClone.SetActive(false);
        iceCube.SetActive(false);
        speed = 8;
        ballClone.transform.position = new Vector2(Random.Range(-7.4f, 7.33f), 6f);
        spikes.transform.position = new Vector2(Random.Range(-8.3f, 8.24f), -1.55f);
        Physics2D.IgnoreLayerCollision(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        //Powerups - Ice Cube, Spring, Heart, lava, fake ball, spikes. "Spikes are on CK_BallScript.cs".
        timer += Time.deltaTime;
        if(CK_Display.score == Random.Range(10, 15)){
            ballClone.SetActive(true);
            print(ballClone.transform.position);
        }
        if(timer == 0f)
        {
            CK_DisplayScore.UpdateScores(CK_Display.score);
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.score = 0;
            CK_Display.lives = 1;
        }
        if(timer > 5f)
        {
            if (iceCube != null)
            {
                iceCube.SetActive(true);
                iceCube.GetComponent<Rigidbody2D>().velocity += new Vector2(-0.5f, 0.5f);
            }
        }
        if(timer > 5f)
        {
            if (heart != null)
            {
                heart.SetActive(true);
                heart.GetComponent<Rigidbody2D>().velocity += new Vector2(-0.5f, 0.5f);
            }
        }
        if(timer > 6f)
        {
            if (spring != null)
            {
                spring.SetActive(true);
                spring.GetComponent<Rigidbody2D>().velocity += new Vector2 (-0.5f, 0.5f);
            }
        }
        if(timer > 5f)
        {
            spikes.SetActive(true);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.CompareTag("ballFake"))
        {
            CK_Display.lives = 0;
            SceneManager.LoadScene("CK_StartScreen");
            CK_DisplayScore.UpdateScores(CK_Display.score);
            CK_Display.score = 0;
            Destroy(GameObject.Find("player"));
            CK_Display.lives = 1;
        }
        else if(other.gameObject.CompareTag("spikes"))
        {
            CK_Display.lives = 0;
            CK_DisplayScore.UpdateScores(CK_Display.score);
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.score = 0;
            Destroy(GameObject.Find("player"));
            CK_Display.lives = 1;
        }
        else if(other.gameObject.CompareTag("speedPower"))
        {
            Destroy(iceCube);
            iceCube = null;
            ball.GetComponent<Rigidbody2D>().velocity = (ball.GetComponent<Rigidbody2D>().velocity)/3;
            ballClone.GetComponent<Rigidbody2D>().velocity = (ballClone.GetComponent<Rigidbody2D>().velocity)/3;
        }
        else if(other.gameObject.CompareTag("CKSpring"))
        {
            CK_PlayerMove.jumpHeight = 12f;
            Destroy(spring);
            spring = null;
        }
        else if(other.gameObject.CompareTag("Heart"))
        {
            Destroy(heart);
            heart = null;
            CK_Display.lives++;
        }
    }

}
