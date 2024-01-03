using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSD_display : MonoBehaviour
{
    float timeLeft = 30.0f;

    void Start()
    {

    }

    void Update()
    {
        print(timeLeft);
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            print("X");
            SceneManager.LoadScene("NSD_End");
        }
    }
}
