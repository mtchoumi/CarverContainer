using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LDG_Display2 : MonoBehaviour {
    [SerializeField]private float topLocation = 20f;
    public static float score = 3f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.green;
        gs.fontSize = 20;
        GUI.Box(new Rect(0, 0, 200, 48), "Lives:" + score, gs);
        GUI.EndGroup();
    }
     void Update()
    {    
       if (LDG_Display2.score == 0)
        {
        SceneManager.LoadScene("LDG_DeathScreen"); 
        }
    }
}


