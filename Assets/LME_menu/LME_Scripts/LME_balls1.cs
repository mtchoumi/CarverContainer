using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LME_balls1 : MonoBehaviour
{
    public GameObject prefab;
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "maintarget_default")
        {
            LME_score.score += 1;
            Destroy(col.gameObject);
            Destroy(gameObject);

            //if(LME_score.score > 13)

            //play the animation
            //set the gravity scale to 1
            //destroy the object when it hits the ground
        }
    }
}
