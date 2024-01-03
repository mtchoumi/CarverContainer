using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soo_btn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  if (Input.GetMouseButtonDown(0))
        // {
        //       //loads the screen
        // }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("soo_gamescene1");
    }

    public void NextGame()
    {
        QuickPlay.nextScene();
    }
}
