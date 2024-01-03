using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SEP_RenScene2Main : MonoBehaviour
{
    private float timer2 = 0f;
    public static float timer3 = 0f;
    public static int WhichKey = 0;
    private float interval2 = 8f;
    public static float interval = 1f;
    private int score;
    private bool disable = true;
    private float x = 0;
    private int y = 0;
    GameObject Arrows;
    // Start is called before the first frame update
    void Start()
    {
        Arrows = GameObject.Find("Arrows");
        SEP_MenuScript.stageNum = 2;
        WhichKey = Random.Range(1,5);
        x = Random.Range(-9,-3.5f);
        y = Random.Range(-2,2);
        SEP_ScoreDisplay1.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Arrows.transform.position.x < -9 || Arrows.transform.position.y > 5 || Arrows.transform.position.x > -4 || Arrows.transform.position.y < -4)
        {
            transform.position = new Vector3(-5,1, 0);
        }
        timer3 += Time.deltaTime;
        timer2 += Time.deltaTime;
        if(timer2 > 9f)
        {
            if(SEP_ScoreDisplay1.score < 8)
            {
                SEP_MenuScript.starNum = 0;
            }
            if(SEP_ScoreDisplay1.score >= 8 && SEP_ScoreDisplay1.score < 12)
            {
                SEP_MenuScript.starNum = 1;
            }
            if(SEP_ScoreDisplay1.score >= 12 && SEP_ScoreDisplay1.score < 18)
            {
                SEP_MenuScript.starNum = 2;
            }
            if(SEP_ScoreDisplay1.score >= 18)
            {
                SEP_MenuScript.starNum = 3;
            }
            SceneManager.LoadScene("SEP_MenuScene");
        }
        
    
        if(timer2 <= interval2)
        {
            if(timer3 >= interval)
            {
                WhichKey = Random.Range(1,5);
                disable = true;
                timer3 = 0f;
            }
                if(WhichKey == 1)
                {
                    x = Random.Range(-2,0);
                    y = Random.Range(-2,2); 
                    SEP_GetArrows.UArrow.SetActive(true);
                    SEP_GetArrows.DArrow.SetActive(false);
                    SEP_GetArrows.LArrow.SetActive(false);
                    SEP_GetArrows.RArrow.SetActive(false);
                if(disable == true)
                {
                    transform.position = transform.position + new Vector3(x,y, 0);
                    disable = false;
                }
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SEP_ScoreDisplay1.score++;
                    SEP_GetArrows.UArrow.SetActive(false); //Make it switch sprites when done?

                }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SEP_ScoreDisplay1.score--;
                }
                }else if(WhichKey == 2)
                {
                    x = Random.Range(0,2);
                    y = Random.Range(-2,2);
                    SEP_GetArrows.DArrow.SetActive(true);
                    SEP_GetArrows.UArrow.SetActive(false);
                    SEP_GetArrows.LArrow.SetActive(false);
                    SEP_GetArrows.RArrow.SetActive(false);
                    if(disable == true)
                    {
                        transform.position = transform.position + new Vector3(x,y, 0);
                        disable = false;
                    }
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SEP_ScoreDisplay1.score++;
                    SEP_GetArrows.DArrow.SetActive(false);
                }else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SEP_ScoreDisplay1.score--;
                }
            }else if(WhichKey == 3)
            {
                x = Random.Range(0,2);
                y = Random.Range(-2,2);
               SEP_GetArrows.LArrow.SetActive(true);
               SEP_GetArrows.UArrow.SetActive(false);
               SEP_GetArrows.RArrow.SetActive(false);
               SEP_GetArrows.DArrow.SetActive(false);
               if(disable == true)
                {
                    transform.position = transform.position + new Vector3(x,y, 0);
                    disable = false;
                }
               if(Input.GetKeyDown(KeyCode.LeftArrow))
               {
                   SEP_ScoreDisplay1.score++;
                   SEP_GetArrows.LArrow.SetActive(false);
               }else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                   SEP_ScoreDisplay1.score--;
                }
            }else if(WhichKey == 4)
            {
                x = Random.Range(0,2);
                y = Random.Range(-2,2);
                SEP_GetArrows.RArrow.SetActive(true);
                SEP_GetArrows.DArrow.SetActive(false);
                SEP_GetArrows.UArrow.SetActive(false);
                SEP_GetArrows.LArrow.SetActive(false);
                if(disable == true)
                {
                    transform.position = transform.position + new Vector3(x,y, 0);
                    disable = false;
                }
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SEP_ScoreDisplay1.score++;
                    SEP_GetArrows.RArrow.SetActive(false);
                }else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SEP_ScoreDisplay1.score--;
                }
            }
        }
    }
}
