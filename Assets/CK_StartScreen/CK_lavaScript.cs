using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CK_lavaScript : MonoBehaviour
{
    public static GameObject lava;
    private float Ltimer;
    private int interval;
    // Start is called before the first frame update
    void Start()
    {
        lava = GameObject.Find("lava");
        lava.GetComponent<SpriteRenderer>().enabled = false;
        Physics2D.IgnoreCollision(GameObject.Find("ground").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Ltimer = 0;
        interval = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Ltimer += Time.deltaTime;
        if(CK_Display.score >= 5)
        {
            lava.GetComponent<SpriteRenderer>().enabled = true;
            if(Ltimer >= interval)
            {
                Instantiate(lava, new Vector3(Random.Range(-8.73f, 9.15f), -4.53f, 0), Quaternion.identity);
                Ltimer = 0f;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        print("hit");
        if(other.gameObject.CompareTag("Player") && lava.GetComponent<SpriteRenderer>().enabled == true)
        {
            Destroy(GameObject.Find("player"));
            CK_DisplayScore.UpdateScores(CK_Display.score);
            SceneManager.LoadScene("CK_StartScreen");
            CK_Display.score = 0;
            CK_Display.lives = 1;
        }
    }    
}
