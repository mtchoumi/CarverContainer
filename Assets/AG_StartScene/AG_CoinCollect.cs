using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_CoinCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "coin")
        {
            Destroy(col.gameObject);
            AG_Display.score++;
        }
    }
  
}
