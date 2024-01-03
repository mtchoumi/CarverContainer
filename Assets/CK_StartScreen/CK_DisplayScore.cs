using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class CK_DisplayScore : MonoBehaviour
{
    private float topLocation = 7f;
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public int score5;
    public static int [] scores = new int[]{0,0,0,0,0};
    public static GameObject txtScores;
    // Start is called before the first frame update
    void Start()
    {
        txtScores = GameObject.Find("highScores");
        txtScores.GetComponent<Text>().text = "Top Scores: " + scores[0] + ", " + scores[1] + ", " + scores[2] + ", " + scores[3] + ", " + scores[4];
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.yellow;
        gs.fontSize = 14;
        //GUI.Box(new Rect (0, 0, 400, 25), gs);
        GUI.EndGroup();
    }
    public static void UpdateScores(int currentScore)
    {
        for(int i = 0; i < scores.Length; i++)
        {
            if(scores[i] < currentScore)
            {
              int temp = scores[i];
              scores[i] = currentScore;
              currentScore = temp;   
            }
        }
    }
    public static void presentScores()
    {
        print(txtScores);
        txtScores.GetComponent<Text>().text = "Top Scores: " + scores[0] + ", " + scores[1] + ", " + scores[2] + ", " + scores[3] + ", " + scores[4];  
    }
}
