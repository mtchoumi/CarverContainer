using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSQ_ScoreLvL3 : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score3 = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.white;
        gs.fontSize = 30;
        GUI.Box(new Rect(0, 0, 400, 25), "Target: 250   Score:" + score3, gs);
        GUI.EndGroup();
        if(score3 >= 250){
            SceneManager.LoadScene("NSQ_Lvl3Comp");
            score3=0;
        }
    }
}