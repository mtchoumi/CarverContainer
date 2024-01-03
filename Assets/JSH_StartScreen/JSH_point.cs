using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSH_point : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name  == "JSH_Player")
        {
            // if(Input.GetKeyDown(KeyCode.Space))
            // {
                JSH_objectPoint.rn = Random.Range(1,17);
                //print(rn);
                JSH_Display.score++;
                Destroy(gameObject);
            // }
        }
    }
}
