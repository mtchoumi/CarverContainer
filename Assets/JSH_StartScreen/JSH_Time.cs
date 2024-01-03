using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JSH_Time : MonoBehaviour {
    [SerializeField]private float topLocation = 18f;
    public static int time = 30;
    int Timer = 60;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, topLocation, 400, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 14;
        GUI.Box(new Rect(0, 0, 400, 25), "Time:" + time, gs);
        GUI.EndGroup();
    }
    void Update()
    {
        Timer--;
        if(Timer <= 0)
        {
            Timer = 60;
            time--;
        }
        if(time <= 0)
        {
            QuickPlay.nextScene();
        }
    }
}
