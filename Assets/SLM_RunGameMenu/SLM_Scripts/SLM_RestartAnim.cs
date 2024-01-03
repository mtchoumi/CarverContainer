using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SLM_RestartAnim : MonoBehaviour
{
    private int time;
    private float convert;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        convert = 0;
    }

    // Update is called once per frame
    void Update()
    {
        convert += Time.deltaTime;
        if(convert>=1){
            time++;
       //     print("time going up");
            convert=0;
        }
        if(time==20){
            SceneManager.LoadScene("SLM_RunGameMenu");
        }
    }
}
