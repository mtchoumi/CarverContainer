using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VFL_PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private float topLocation = 50f;
    public static float playerHealth = 250f;
    private void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleCenter;
        GUI.BeginGroup(new Rect(Screen.width / 2 - 200, topLocation, 400, 50));
        gs.normal.textColor = Color.yellow;
        gs.fontSize = 14;
        GUI.Box(new Rect(0, 0, 400, 25), "Player Health::" + playerHealth, gs);
        GUI.EndGroup();
    }
    void Update(){
        if(playerHealth == 0f || playerHealth < 0f){
            SceneManager.LoadScene("VFL_LoseScreen");
        }
    }
}
