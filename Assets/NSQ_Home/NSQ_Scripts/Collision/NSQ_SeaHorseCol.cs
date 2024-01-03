using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSQ_SeaHorseCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            NSQ_ScoreLvL3.score3 += 12;
        }
    }
}
