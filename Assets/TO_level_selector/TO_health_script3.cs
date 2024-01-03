using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_health_script3 : MonoBehaviour
{
    Renderer re;
     //Start is called before the first frame update
    void Start()
    {
        re = GetComponent<Renderer>();
        re.enabled = false;
        TO_health_script1.health = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_health_script1.health == 1)
        {
            re.enabled = true;
        }
    }
}
