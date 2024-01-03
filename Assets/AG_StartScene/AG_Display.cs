using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Display : MonoBehaviour {
    [SerializeField]private float topLocation = 15f;
    public static float score = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.black;
        gs.fontSize = 30;
        GUI.Box(new Rect(0, 0, 400, 25), score + "/" + "20" + "  Coins Collected", gs);
        GUI.EndGroup();
    }
}
