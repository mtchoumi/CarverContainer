using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JEK1_Spinn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    { 
        if(col.gameObject.name == "Trex_2")
        { 
            //SceneManager.LoadScene("Death");
            SceneManager.LoadScene("JEK1_Death");
            //Destroy(col.gameObject);   
        }    
    }
}
