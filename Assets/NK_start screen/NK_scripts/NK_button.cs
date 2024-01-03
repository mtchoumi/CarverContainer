using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NK_button : MonoBehaviour
{
   public void LoadScene(string sceneName)
   {
       if (sceneName == "Loading")
       {
           QuickPlay.nextScene();
       }
       else
       {
            SceneManager.LoadScene(sceneName);
       }
   }
}
