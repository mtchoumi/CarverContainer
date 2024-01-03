using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RMG_countdown : MonoBehaviour
{
    //public static 
    int timer = 30;
    [SerializeField] float interval = 1;
    float time = 0.0f;
    bool hasStarted = false;
    /*public static*/ int seconds = 0;
    Text text;
    [SerializeField] string attachedTo;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if(attachedTo == "startBanner")
        {
            text.text = "3";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval)
        {
            if(seconds >= 0 && seconds <= 4)
            {
                seconds++;
                if(attachedTo == "startBanner")
                {
                    if(seconds == 1)
                    {
                        text.text = "2";
                    }
                    else if(seconds == 2)
                    {
                        text.text = "1";
                    }
                    else if(seconds ==  3)
                    {
                        text.text = "Go!";
                        Destroy(GameObject.Find("GameObject"));
                    }
                    else
                    {
                        Destroy(GameObject.Find("start banner text"));
                        Destroy(GameObject.Find("start banner"));
                    }
                }
                if(seconds == 4)
                {
                    hasStarted = true;
                }
            }
            if(hasStarted)
            {
                if(attachedTo == "countdown")
                {
                    timer--;
                    //GUILayout.Label(timer.ToString());
                    text.text = ":" + timer.ToString();
                    if (timer <= 0 || GameObject.Find("red_car") == null && GameObject.Find("green_car") == null && GameObject.Find("pink_car") == null && GameObject.Find("purple_car") == null)
                    {
                        SceneManager.LoadScene("RMG_endscreen");  
                    } 
                }
                if(attachedTo == "places")
                {
                    
                        if(gameObject.name == "First place")
                        {
                            text.text = "1st Place: " + RMG_leaderboard.leaderboard[0];
                        }
                        else if(gameObject.name == "Second place")
                        {
                            text.text = "2nd Place: " + RMG_leaderboard.leaderboard[1];
                        }
                        else if(gameObject.name == "Third place")
                        {
                            text.text = "3rd Place: " + RMG_leaderboard.leaderboard[2];
                        }
                        else if(gameObject.name == "Fourth place")
                        {
                            text.text = "4th Place: " + RMG_leaderboard.leaderboard[3];
                        }
                }
                if(attachedTo == "advanceToNextGame")
                {
                    timer--;
                    if(timer == 30)
                    {
                        text.text = "Next Game In 3";
                    }
                    else if(timer == 29)
                    {
                        text.text = "Next Game In 2";
                    }
                    else if(timer == 28)
                    {
                        text.text = "Next Game In 1";
                    }
                    else if(timer <= 27)
                    {
                        QuickPlay.nextScene();
                    }
                }
                
            }
            time = 0f;
        }
    }
}
