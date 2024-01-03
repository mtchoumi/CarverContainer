using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soo_backtomain : MonoBehaviour
{
      GameObject boatfixed;
      bool spacePressed;
    // Start is called before the first frame update
    void Start()
    {
          spacePressed = false; 
            boatfixed = GameObject.Find("boatfixed"); 
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("space")){
            spacePressed = true;
        }
         if(spacePressed == true){
       boatfixed.SetActive(false); 
            }
    }
}
