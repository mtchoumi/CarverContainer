﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_shotscript3 : MonoBehaviour
{
    Renderer re;
    // Start is called before the first frame update
    void Start()
    {
        re = GetComponent<Renderer>();
        re.enabled = false;
        TO_Playermove.shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_Playermove.shots == 2)
        {
            re.enabled = true;
        }
    }
}