using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEP_UPArrow : MonoBehaviour
{
    //ADD rigidbody variable
    
    void Start()
    {
        SEP_GetArrows.UArrow.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SEP_Scene2Main2.timer3 > SEP_Scene2Main2.interval)
        {
            if(SEP_Scene2Main2.WhichKey == 1)
                {
                    transform.position = transform.position + new Vector3(Random.Range(0,5),Random.Range(0,5), 0);
                    SEP_GetArrows.UArrow.SetActive(true);
                } 
        }
    }
}
