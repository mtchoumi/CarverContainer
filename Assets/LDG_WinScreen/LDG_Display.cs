using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LDG_Display : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score = 0f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.green;
        gs.fontSize = 20;
        GUI.Box(new Rect(0, 0, 600, 25), "Score:" + score, gs);
        GUI.EndGroup();
    }
     void Update()
    {    
       if (LDG_Display.score == 30)
        {
        SceneManager.LoadScene("LDG_WinScreen"); 
        }
    }
}
