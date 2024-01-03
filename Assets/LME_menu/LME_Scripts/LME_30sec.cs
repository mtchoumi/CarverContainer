using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LME_30sec : MonoBehaviour
{
    [SerializeField]private float topLocation = 20f;
    //public static float score = 0f;
    
    // void OnGUI()
    // {
    //     GUIStyle gs = new GUIStyle();
    //     gs.alignment = TextAnchor.MiddleCenter;
    //     GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
    //     gs.normal.textColor = Color.yellow;
    //     gs.fontSize = 14;
    //     GUI.Box(new Rect(0, 0, 400, 25), "time:" + Mathf.Round(time), gs);
    //     GUI.EndGroup();
    // }

    public float interval = 30; 
    float time = 0.0f; 

    void Update()
    {
        GameObject.Find("Text").GetComponent<Text>().text=""+Mathf.FloorToInt(time);
        
        time += Time.deltaTime; 
        if (time >= 30)
        {
            SceneManager.LoadScene("LME_ohno" + LME_score.level);
            time = 0f;
        }

        if(LME_score.score == 14)
        {
            SceneManager.LoadScene("LME_congrats" + LME_score.level);
            LME_score.score = 0;
        }
    }
}