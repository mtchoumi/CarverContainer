using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CK_ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("CK_BallBounceScene");
        }
    }
    public void onButtonPress()
    {
        SceneManager.LoadScene("CK_BallBounceScene");
        CK_Display.lives = 1;
        CK_Display.score = 0;
    }
}
