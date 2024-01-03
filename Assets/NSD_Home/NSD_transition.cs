using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSD_transition : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        NSD_Display.score++;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            NSD_Display.score = 0;
        SceneManager.LoadScene("NSD_Game");
        }

        if(Input.GetKey(KeyCode.A))
        {
        SceneManager.LoadScene("NSD_Home");
        }

        if (Input.GetKey(KeyCode.D))
        {
            QuickPlay.nextScene();
        }
    }
}
