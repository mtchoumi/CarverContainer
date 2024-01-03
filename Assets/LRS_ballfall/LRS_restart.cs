using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LRS_restart : MonoBehaviour
{
    // Start is called before the first frame update
    public static float num;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            LRS_you.num= 0;
        SceneManager.LoadScene("LRS_ballfall");
        } 
        if (Input.GetKey(KeyCode.Q))
        {
            QuickPlay.nextScene();
        }
    }
}
