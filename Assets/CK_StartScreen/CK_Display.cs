using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CK_Display : MonoBehaviour 
{
    private float topLocation = 6.5f;
    public static int score = 0;
    public static int lives = 1;
    public static float gTime = 30f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 14;
        GUI.Box(new Rect(0, 0, 400, 25), "Score: " + score, gs);
        GUI.Box(new Rect(0, 0, 400, 60), "HP: " + lives, gs);
        GUI.Box(new Rect(0, 0, 400, 85), "Time: " + Mathf.Floor(gTime), gs);
        GUI.EndGroup();
    }
}
