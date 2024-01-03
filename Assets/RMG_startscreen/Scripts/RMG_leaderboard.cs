using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RMG_leaderboard : MonoBehaviour
{
    public static int red_car_score = 0;
    public static int green_car_score = 0;
    public static int pink_car_score = 0;
    public static int purple_car_score = 0;
    [SerializeField] float interval = 1;
    float time = 0.0f;
    bool hasStarted = false;
    int seconds = 0;
    Text text;
    [SerializeField] string attachedTo;
    SpriteRenderer sr;
    public static string[] leaderboard = {"", "", "", ""};
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        sr = GetComponent<SpriteRenderer>();
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
                if(seconds == 4)
                {
                    hasStarted = true;
                }
            }
            if(hasStarted)
            {
                if(seconds == 4)
                {
                    if(gameObject.name == "leaderboard background" || gameObject.name == "1" || gameObject.name == "2" || gameObject.name == "3" || gameObject.name == "4")
                    {
                        transform.Translate(0f, 9f, 0f);
                    }
                }
                if(seconds >= 4)
                {
                    if(gameObject.name == "1" || gameObject.name == "2" || gameObject.name == "3" || gameObject.name == "4")
                    {
                        if(gameObject.name == "1")
                        {
                            if(red_car_score > green_car_score && red_car_score > pink_car_score && red_car_score > purple_car_score)
                            {
                                
                                if(red_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("1 is red");
                                    text.color = Color.red;
                                    leaderboard[0] = "Red";
                                }
                                

                            }
                            if(green_car_score > red_car_score && green_car_score > pink_car_score && green_car_score > purple_car_score)
                            {
                                if(green_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("1 is green");
                                    text.color = Color.green;
                                    leaderboard[0] = "Green";
                                }
                            }
                            if(pink_car_score > green_car_score && pink_car_score > red_car_score && pink_car_score > purple_car_score)
                            {
                                if(pink_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("1 is pink");
                                    text.color = new Color(236/255f, 70/255f, 177/255f);
                                    leaderboard[0] = "Pink";
                                }
                            }
                            if(purple_car_score > green_car_score && purple_car_score > pink_car_score && purple_car_score > red_car_score)
                            {
                                if(purple_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("1 is purple");
                                    text.color = new Color(151/255f, 33/255f, 200/255f);
                                    leaderboard[0] = "Purple";
                                }
                            }
                        }
                        if(gameObject.name == "2")
                        {
                            if(green_car_score > red_car_score && red_car_score > pink_car_score && red_car_score > purple_car_score ||
                            pink_car_score > red_car_score && red_car_score > green_car_score && red_car_score > purple_car_score || 
                            purple_car_score > red_car_score && red_car_score > green_car_score && red_car_score > pink_car_score)
                            {
                                if(red_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("2 is red");
                                    text.color = Color.red;
                                    leaderboard[1] = "Red";
                                }
                            }
                            if(red_car_score > green_car_score && green_car_score > pink_car_score && green_car_score > purple_car_score ||
                            pink_car_score > green_car_score && green_car_score > red_car_score && red_car_score > purple_car_score || 
                            purple_car_score > green_car_score && green_car_score > red_car_score && green_car_score > pink_car_score)
                            {
                                if(green_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("2 is green");
                                    text.color = Color.green;
                                    leaderboard[1] = "Green";
                                }
                            }
                            if(green_car_score > pink_car_score && pink_car_score > red_car_score && pink_car_score > purple_car_score ||
                            red_car_score > pink_car_score && pink_car_score > green_car_score && pink_car_score > purple_car_score || 
                            purple_car_score > pink_car_score && pink_car_score > green_car_score && pink_car_score > red_car_score)
                            {
                                if(pink_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("2 is pink");
                                    text.color = new Color(236/255f, 70/255f, 177/255f);
                                    leaderboard[1] = "Pink";
                                }
                            }
                            if(green_car_score > purple_car_score && purple_car_score > pink_car_score && purple_car_score > red_car_score ||
                            pink_car_score > purple_car_score && purple_car_score > green_car_score && purple_car_score > red_car_score || 
                            red_car_score > purple_car_score && purple_car_score > green_car_score && purple_car_score > pink_car_score)
                            {
                                if(purple_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("2 is purple");
                                    text.color = text.color = new Color(151/255f, 33/255f, 200/255f);
                                    leaderboard[1] = "Purple";
                                }
                            }
                        }
                        if(gameObject.name == "3")
                        {
                            if(green_car_score > red_car_score && purple_car_score > red_car_score && red_car_score > pink_car_score ||
                            purple_car_score > red_car_score && green_car_score > red_car_score && red_car_score > green_car_score || 
                            pink_car_score > red_car_score && green_car_score > red_car_score && red_car_score > purple_car_score)
                            {
                                if(red_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("3 is red");
                                    text.color = Color.red;
                                    leaderboard[2] = "Red";
                                }
                            }
                            if(red_car_score > green_car_score && purple_car_score > green_car_score && green_car_score > pink_car_score ||
                            purple_car_score > green_car_score && pink_car_score > green_car_score && green_car_score > red_car_score || 
                            pink_car_score > green_car_score && purple_car_score > green_car_score && green_car_score > red_car_score)
                            {
                                if(green_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("3 is green");
                                    text.color = Color.green;
                                    leaderboard[2] = "Green";
                                }
                            }
                            if(green_car_score > pink_car_score && red_car_score > pink_car_score && pink_car_score > purple_car_score ||
                            red_car_score > pink_car_score && green_car_score > pink_car_score && pink_car_score > purple_car_score || 
                            purple_car_score > pink_car_score && red_car_score > pink_car_score && pink_car_score > red_car_score)
                            {
                                if(pink_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("3 is pink");
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                    leaderboard[2] = "Pink";
                                }
                            }
                            if(green_car_score > purple_car_score && pink_car_score > purple_car_score && purple_car_score > red_car_score ||
                            pink_car_score > purple_car_score && red_car_score > purple_car_score && purple_car_score > green_car_score || 
                            red_car_score > purple_car_score && green_car_score > purple_car_score && purple_car_score > pink_car_score)
                            {
                                if(purple_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("3 is purple");
                                    text.color = new Color(151/255f, 33/255f, 200/255f);
                                    leaderboard[2] = "Purple";
                                }
                            }
                        }
                        if(gameObject.name == "4")
                        {
                            if(green_car_score > red_car_score && pink_car_score > red_car_score && purple_car_score > red_car_score ||
                            pink_car_score > red_car_score && purple_car_score > red_car_score && green_car_score > red_car_score || 
                            purple_car_score > red_car_score && green_car_score > red_car_score && pink_car_score > red_car_score)
                            {
                                if(red_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("4 is red");
                                    text.color = Color.red;
                                    leaderboard[3] = "Red";
                                }
                            }
                            if(red_car_score > green_car_score && pink_car_score > green_car_score && purple_car_score > green_car_score ||
                            pink_car_score > green_car_score && purple_car_score > green_car_score && red_car_score > green_car_score || 
                            purple_car_score > green_car_score && red_car_score > green_car_score && pink_car_score > green_car_score)
                            {
                                if(green_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("4 is green");
                                    text.color = Color.green;
                                    leaderboard[3] = "Green";
                                }
                            }
                            if(green_car_score > pink_car_score && red_car_score > pink_car_score && purple_car_score > pink_car_score ||
                            red_car_score > pink_car_score && purple_car_score > pink_car_score && green_car_score > pink_car_score || 
                            purple_car_score > pink_car_score && green_car_score > pink_car_score && red_car_score > pink_car_score)
                            {
                                if(pink_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("4 is pink");
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                    leaderboard[3] = "Pink";
                                }
                            }
                            if(green_car_score > purple_car_score && pink_car_score > purple_car_score && red_car_score > purple_car_score ||
                            pink_car_score > purple_car_score && red_car_score > purple_car_score && green_car_score > purple_car_score || 
                            red_car_score > purple_car_score && green_car_score > purple_car_score && pink_car_score > purple_car_score)
                            {
                                if(purple_car_score <= 0)
                                {
                                    text.color = new Color(76/255f, 167/255f, 180/255f);
                                }
                                else
                                {
                                    // print("4 is purple");
                                    text.color = new Color(151/255f, 33/255f, 200/255f);
                                    leaderboard[3] = "Purple";
                                }
                            }
                        }
                        
                    }
                    if(attachedTo == "red_score")
                    {
                        if(red_car_score < 10)
                        {
                            text.text = "0" + red_car_score.ToString();
                        }
                        else
                        {
                            text.text = red_car_score.ToString();
                        }
                        
                    }
                    if(attachedTo == "green_score")
                    {
                        if(green_car_score < 10)
                        {
                            text.text = "0" + green_car_score.ToString();
                        }
                        else
                        {
                            text.text = green_car_score.ToString();
                        }
                        
                    }
                    if(attachedTo == "pink_score")
                    {
                        if(pink_car_score < 10)
                        {
                            text.text = "0" + pink_car_score.ToString();
                        }
                        else
                        {
                            text.text = pink_car_score.ToString();
                        }
                        
                    }
                    if(attachedTo == "purple_score")
                    {
                        if(purple_car_score < 10)
                        {
                            text.text = "0" + purple_car_score.ToString();
                        }
                        else
                        {
                            text.text = purple_car_score.ToString();
                        }
                        
                    }
                }
            }
            time = 0f;
        }
    }
}