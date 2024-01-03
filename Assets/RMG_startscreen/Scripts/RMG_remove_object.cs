using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMG_remove_object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
    // void OnTriggerEnter2D(Collider2D obj)
    // {
    //     if(gameObject.name.Contains("road_spikes"))
    //     {
    //         print("im attached to road spikes");
    //         if(obj.gameObject.name == "red car body" || obj.gameObject.name == "green car body" || obj.gameObject.name == "pink car body" || obj.gameObject.name == "purple car body")
    //         {
    //             Destroy(obj.gameObject);
    //         }
    //     }
        
    // }
}
