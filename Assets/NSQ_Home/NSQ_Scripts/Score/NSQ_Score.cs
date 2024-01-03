using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSQ_Score : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.white;
        gs.fontSize = 30;
        GUI.Box(new Rect(0, 0, 400, 25), "Target: 20   Score:" + score, gs);
        GUI.EndGroup();
        if(score >= 20){
            SceneManager.LoadScene("NSQ_Lvl1Comp");
            score=0;
        }
    }
}