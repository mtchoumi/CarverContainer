using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KNG_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("KNG_Glong");
        }
     
    
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("KNG_Glong");
        }
         
        if (Input.GetKey(KeyCode.B))
        {
            QuickPlay.nextScene();
        } 
    }

}
