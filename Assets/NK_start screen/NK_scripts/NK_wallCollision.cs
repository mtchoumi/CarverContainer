﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_wallCollision : MonoBehaviour
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
    if (col.gameObject.CompareTag("Enemy"))
    Destroy(col.gameObject);
    if (col.gameObject.CompareTag("Bullet"))
    Destroy(col.gameObject);
    }
}
