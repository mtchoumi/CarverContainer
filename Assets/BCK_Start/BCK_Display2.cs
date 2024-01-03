using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCK_Display2 : MonoBehaviour {
    [SerializeField]private float topLocation = 120f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 700, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 28;
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(0, 0, 400, 25), "" + BCK_Display.score, gs);
        GUI.EndGroup();
    }
}
