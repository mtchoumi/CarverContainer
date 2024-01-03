using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LKC_PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0))
        // {
        //      SceneManager.LoadScene("LKC_Cup1");
        // } 
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("LKC_Cup1");
    }

    public void Quitgame()
    {
        QuickPlay.nextScene();
    }
}
