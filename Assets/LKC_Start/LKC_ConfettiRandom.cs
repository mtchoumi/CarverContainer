using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKC_ConfettiRandom : MonoBehaviour
{
    
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    { 
        rotation +=0.5f;
        transform.rotation = Quaternion.Euler(0f,0f, rotation);
    }
}
