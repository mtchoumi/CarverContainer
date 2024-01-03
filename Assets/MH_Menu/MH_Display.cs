using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Display : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.red;
        gs.fontSize = 32;
        GUI.Box(new Rect(0, 0, 400, 25), "Score:" + score, gs);
        GUI.EndGroup();
    }
}
