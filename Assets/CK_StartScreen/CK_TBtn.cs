using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CK_TBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //implement B button
    }
    public void onButtonPress()
    {
        SceneManager.LoadScene("CK_Tutorial");
    }

}
