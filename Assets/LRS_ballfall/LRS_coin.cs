using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRS_coin : MonoBehaviour
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
        if (col.gameObject.name == "you")
        {
            Destroy(gameObject);
        }
    }
}
