using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LKC_End : MonoBehaviour
{
    // Start is called before the first frame update
    static float end;
    float time = 0.0f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime; 
        if(time>=7)
        {
            print("done");
            //Application.Quit();
            QuickPlay.nextScene();
        }
    }
}
