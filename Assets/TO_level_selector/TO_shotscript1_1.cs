using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_shotscript1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TO_Playermove.shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_Playermove.shots == 2)
        {
            Destroy(GameObject.Find("shot2"));
        }
    }
}
