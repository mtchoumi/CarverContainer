﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_bob : MonoBehaviour
{
    public float amp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (6, Mathf.Sin(Time.time)* amp, 2);
    }
}