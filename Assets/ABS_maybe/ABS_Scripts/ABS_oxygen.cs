using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABS_oxygen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3 (ABS_player.timer/5f,1,1);
    }
}
