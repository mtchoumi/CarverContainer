using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SLM_SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void SLM_GoToMainScene(){
        SceneManager.LoadScene("SLM_RunGame");
    }
  public  void SLM_GoToMainMenu(){
        SceneManager.LoadScene("SLM_RunGameMenu");
    }
  public  void SLM_GoToWinScreen(){
        SceneManager.LoadScene("SLM_RunGameWin");
    }
    public void SLM_GoToLoseScreen(){
        SceneManager.LoadScene("SLM_RunGameOver");
    }
    public void SLM_QuitTheGame(){
      //  SceneManager.LoadScene("Loading");
      //Application.Quit();
       QuickPlay.nextScene();
    }

}
