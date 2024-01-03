using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SEP_Scene1Main : MonoBehaviour
{
    private float timer1 = 0f;
    private int WhichKey = 0;
    [SerializeField] private GameObject LArrow;
    [SerializeField] private GameObject RArrow;
    [SerializeField] private GameObject UArrow;
    [SerializeField] private GameObject DArrow;
    public int WinLose = 0;
    // Start is called before the first frame update
    void Start()
    {
        UArrow.SetActive(false);
        DArrow.SetActive(false);
        SEP_MenuScript.stageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 += Time.deltaTime;
        if(timer1<4f)
        {
            RArrow.SetActive(true);
            LArrow.SetActive(true);
        }
        if(timer1 > 4f)
        {
            UArrow.SetActive(true);
            UArrow.SetActive(true);
            WhichKey = 1; 
            LArrow.SetActive(false);
            RArrow.SetActive(false);
        }
        if(WhichKey == 0 && timer1 <= 10f)
        {    
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                RArrow.SetActive(false);
                SEP_ScoreDisplay1.score++;
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LArrow.SetActive(false);
                SEP_ScoreDisplay1.score++;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                SEP_ScoreDisplay1.score--;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                SEP_ScoreDisplay1.score--;
            }
        } else if(timer1 >= 4f &&  timer1 <= 9f)
        {
            WhichKey = 1;
            UArrow.SetActive(true);
            DArrow.SetActive(true);
            if(WhichKey == 1)
            {
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    UArrow.SetActive(false);
                    SEP_ScoreDisplay1.score++;
                }
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    DArrow.SetActive(false);
                    SEP_ScoreDisplay1.score++;
                }
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    SEP_ScoreDisplay1.score--;
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    SEP_ScoreDisplay1.score--;
                }
            }
        }
        if(timer1 >= 9f)
        {
            if(SEP_ScoreDisplay1.score <= 20)
                {
                   SEP_MenuScript.starNum = 0;
                }else if (SEP_ScoreDisplay1.score >= 70) 
                {
                    SEP_MenuScript.starNum = 3;
                }else if (SEP_ScoreDisplay1.score >= 40 && SEP_ScoreDisplay1.score <= 70)
                {
                    SEP_MenuScript.starNum = 2;
                }else if (SEP_ScoreDisplay1.score >= 30 && SEP_ScoreDisplay1.score < 40)
                {
                    SEP_MenuScript.starNum = 1;
                }
            SceneManager.LoadScene("SEP_MenuScene");
        }
        
    }
}
