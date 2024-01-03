using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LME_balls3 : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "pinktarget_default")
        {
            LME_score.score += 2;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        if(col.gameObject.name == "bluetarget_default")
        {
            LME_score.score -= 1;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}