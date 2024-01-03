using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKC_DestoyConfetti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name.Contains("Square 1")){
            Destroy(col.gameObject);
            print("destroyed");
        }
    }
}
