using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMW_Reset : MonoBehaviour
{
    [SerializeField]private float topLocation = 20f;
    void Start()
    {
        
    }
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.yellow;
        gs.fontSize = 14;
        GUI.Box(new Rect(0, 0, 400, 25), "Press escape to quit", gs);
        GUI.EndGroup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MMW_Main");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            QuickPlay.nextScene();
        }
    }
}
