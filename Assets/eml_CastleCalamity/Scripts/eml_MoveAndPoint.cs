using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eml_MoveAndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    int position = 0;
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(eml_Spawner.totalTimer<20f)
        {    
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                position--;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                position++;
            }
            if(position<-2)
            {
                position = -2;
            }
            if(position>2)
            {
                position = 2;
            }
            transform.position = new Vector2(0f+(position*1.5f)-20f,-4.2f);
        }
    }
}
