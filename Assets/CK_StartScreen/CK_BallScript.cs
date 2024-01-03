using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CK_BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-7.5f, 0f), 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(CK_Display.gTime == 0f)
        {
            SceneManager.LoadScene("CK_StartScreen");
            CK_DisplayScore.UpdateScores(CK_Display.score);
            CK_Display.score = 0;
            CK_Display.lives = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player") && GameObject.Find("player").transform.position.y > -2.710 )
        {
            CK_Display.score++;
        }
        if(other.gameObject.CompareTag("CKGround") && CK_Display.lives > 0 && gameObject.name != "ballClone")
        {
            CK_Display.lives--;
            if(CK_Display.lives == 0)
            {
                CK_Display.lives = 1;
                SceneManager.LoadScene("CK_StartScreen");
                CK_DisplayScore.UpdateScores(CK_Display.score);
                CK_Display.score = 0;
                Destroy(GameObject.Find("player"));
            }
        }
        if(other.gameObject.CompareTag("spikes") && gameObject.name != "ballClone")
        {
            SceneManager.LoadScene("CK_StartScreen");
            CK_DisplayScore.UpdateScores(CK_Display.score);
            CK_Display.score = 0;
            CK_Display.lives = 1;
            Destroy(GameObject.Find("ball"));
        }
    }
}
