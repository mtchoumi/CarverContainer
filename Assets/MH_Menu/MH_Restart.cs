using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
      public void Scene2(){
        SceneManager.LoadScene("MH_Infinite");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
