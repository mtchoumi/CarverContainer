using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LME_balls2 : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "maintarget_default")
        {
            LME_score.score += 1;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
