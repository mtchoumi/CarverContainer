using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DAP_Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DAP_Game");
        DAP_ObjSpawn.Time = 0;
        DAP_ScoreMultiplier.StopScript = false;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("DAP_Titlescreen");
    }

    public void LeaveGame()
    {
        QuickPlay.nextScene();
        //Application.Quit();
    }
}
