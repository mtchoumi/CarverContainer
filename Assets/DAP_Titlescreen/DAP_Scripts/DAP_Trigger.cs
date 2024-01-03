using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DAP_Trigger : MonoBehaviour
{
    public static float FinalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StopCoroutine(DAP_ObjSpawn.SpawnCoroutine);
            FinalScore = (float) (Math.Floor(Convert.ToSingle(DAP_ScoreMultiplier.score)) * Convert.ToSingle(DAP_ObjSpawn.Time));
            
        }
    }
}
