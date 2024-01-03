using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DA_scene4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
      SceneManager.LoadScene("DA_Instructions");
            DA_Score.score = 0;
            DA_timeleft.startingTime = 33;   
    }
}
