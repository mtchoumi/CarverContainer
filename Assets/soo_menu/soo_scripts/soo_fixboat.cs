using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soo_fixboat : MonoBehaviour
{
     GameObject boatsink;
     GameObject boatfixed;
     float timeHeld;
    // Start is called before the first frame update
    void Start()
    {
         timeHeld = 0;  
      boatsink = GameObject.Find("boatsink");
         boatfixed = GameObject.Find("boatfixed");
       boatsink.SetActive(true); 
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("w"))
       {
      timeHeld += Time.deltaTime;
       }
      if (timeHeld >= 1)
      {
      boatfixed.SetActive(true); 
     }
    }
}
