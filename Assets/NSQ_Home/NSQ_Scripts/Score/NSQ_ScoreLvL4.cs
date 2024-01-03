using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSQ_ScoreLvL4 : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score4 = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.white;
        gs.fontSize = 30;
        GUI.Box(new Rect(0, 0, 400, 25), "Target: 500   Score:" + score4, gs);
        GUI.EndGroup();
        if(score4 >= 500){
            SceneManager.LoadScene("NSQ_Lvl4Comp");
            score4=0;
        }
    }
}