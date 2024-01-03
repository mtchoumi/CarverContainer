using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCK_Display : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score = 0f;
    public static float time2 = 31f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, topLocation, 400, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 20;
        GUI.Box(new Rect(0, 0, 400, 25), "Sc're:" + score, gs);
        GUI.EndGroup();

        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 300, topLocation, 400, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 20;
        GUI.Box(new Rect(0, 0, 400, 25), "Timeth:" + (int)time2, gs);
        GUI.EndGroup();
    }
}
