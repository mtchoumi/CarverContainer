using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSQ_Button : MonoBehaviour
{
    public void LvL1()
    {
        SceneManager.LoadScene("NSQ_LvL1");
        //Application.targetFrameRate = 4;
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("NSQ_HowToPLay");
    }
    public void Home()
    {
        SceneManager.LoadScene("NSQ_Home");
        //Application.targetFrameRate = 4;
    }
    public void LvL2()
    {
        SceneManager.LoadScene("NSQ_LvL2");
        //Application.targetFrameRate = 4;
    }
    public void LvL3()
    {
        SceneManager.LoadScene("NSQ_LvL3");
    }
    public void LvL4()
    {
        SceneManager.LoadScene("NSQ_LvL4");
    }

    public void Quit()
    {
        QuickPlay.nextScene();
    }
}