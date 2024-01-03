using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NK_Display : MonoBehaviour {
    public float topLocation = 0f;
    public static float score = 0f;
    public static string message = "message";
    private int scale = 0;
    void Start()
    {
        score = 0f;
        scale = Screen.width;
    }
    void OnGUI()
    {
       
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.red;
        gs.fontSize = 12*scale/425;
        GUI.Box(new Rect(0, 0, 400, 20* scale / 425), "Score:" + score, gs);
        gs.fontSize = 10 *scale/425;
        GUI.Box(new Rect(0, 0, 400, 45* scale / 425), "" + message, gs);
        GUI.EndGroup();
    }
    void Update()
    {
        if (score >=5000)
        {
            SceneManager.LoadScene("NK_win screen");
        }
    }
}
