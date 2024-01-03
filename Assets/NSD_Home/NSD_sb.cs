using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSD_sb : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
        SceneManager.LoadScene("NSD_Game");
        }
        if (Input.GetKey(KeyCode.D))
        {
            QuickPlay.nextScene();
        }
    }
}
