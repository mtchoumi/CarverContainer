using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSB_dragonattack : MonoBehaviour
{   
     public GameObject prefab = null;
     public float interval = 1;
     float time = 0.0f;
     float laser = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       time += Time.deltaTime; //deltaTime is the time in seconds it took to complete last frame
      if (time >= interval)
      {
        if (time >= 1.9f)
        {
         GameObject obj1 = (GameObject)Instantiate(prefab,transform.position,transform.rotation);
         GameObject obj2 = (GameObject)Instantiate(prefab,transform.position,transform.rotation); 
         GameObject obj3 = (GameObject)Instantiate(prefab,transform.position,transform.rotation); 
         interval = Random.Range(0.5f,2f);
         laser = 0f;
        }
        else if (time <= 0.6f && laser < 20)
        {
          interval = 0.25f;
          laser++;
        }
        else
        {
          interval = Random.Range(0.5f,2f);
          laser = 0f;
        }
       GameObject obj4 = (GameObject)Instantiate(prefab,transform.position,transform.rotation); 
          //interval = 2f;
         time = 0f;
      }
    }
}
