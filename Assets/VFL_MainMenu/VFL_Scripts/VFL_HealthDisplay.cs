using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VFL_HealthDisplay : MonoBehaviour
{
    [SerializeField] private float topLocation = 50f;
    public static float bossHealth = 750f;
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.yellow;
        gs.fontSize = 18;
        GUI.Box(new Rect(0, 0, 400, 25), "Boss Health:" + bossHealth, gs);
        GUI.EndGroup();
    }
    void Update()
    {
        if (bossHealth == 0 || bossHealth < 0)
        {
            SceneManager.LoadScene("VFL_WinScreen");
        }
    }
}
