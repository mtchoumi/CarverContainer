using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSB_playbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Return))
    {
     SceneManager.LoadScene("LSB_game");
    }
    }
    void OnMouseDown()
    {
        if (gameObject.name == "LSB_menu_0")
        {
            SceneManager.LoadScene("LSB_game");
        }
        else 
        {
            QuickPlay.nextScene();
            print("go");
        }
    }

}
