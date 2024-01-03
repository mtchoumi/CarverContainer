using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEC_StartMenuInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void onButtonPress()
    {
        SceneManager.LoadScene("SEC_Instructions");
    }

    public void onSecondButtonPress()
    {
        SceneManager.LoadScene("SEC_Game");
    }
}
