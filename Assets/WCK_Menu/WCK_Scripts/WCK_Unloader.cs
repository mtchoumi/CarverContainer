using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// unloading the scene is placed in a seperate file to ensure that no errors will happen

public class WCK_Unloader : MonoBehaviour
{
    // Start is called before the first frame update

    string END_NAME = "WCK_Main";
    long timer = 0;

    void Start()
    {
        timer = 0;
    }
    
    void FixedUpdate()
    {
        timer++;
        if(timer == 60*30) {
            timer++;
            // adding one prevent ending the game immediately if FixedUpdate is called before start
            SceneManager.LoadScene(END_NAME);
            print("LOAD FAILED");
            // attempt to end game after 60 seconds
        }
        if(timer > 60*35 && timer % 60 == 0) {
            timer++;
            SceneManager.LoadScene(END_NAME);
            print("LOAD FAILED");
            // attempt to end game each second after 65 seconds
        }
    }
}
