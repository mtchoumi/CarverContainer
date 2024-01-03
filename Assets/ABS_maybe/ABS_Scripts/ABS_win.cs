using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ABS_win : MonoBehaviour
{
    public Text mtext;
    int testy;
    float endscore;
    void Start()
    {
        testy = (int) System.Math.Round (ABS_player.timer);
        endscore = testy * 25 + ABS_Display.score;
       
    }

    void Update()
    {
        if (ABS_Portal.test == "done")
        {
            mtext.text = "Congrats, Your Score Is " + ABS_Display.score + " And You Had About " + testy + " Second(s) Of Oxygen Left! Your total score is " + endscore + "Press B To Go To The Next Game!";
        }

        if (Input.GetKey(KeyCode.R))
        {
            ABS_Display.score = 0;
            ABS_player.timer = 30;
            SceneManager.LoadScene("ABS_yes");
        }

        if (Input.GetKey(KeyCode.B))
        {
            QuickPlay.nextScene();
        }
    }

    
}
