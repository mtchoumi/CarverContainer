using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_health_script1_1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        TO_health_script1.health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_health_script1.health == 1)
        {
            Destroy(GameObject.Find("life_2"));
        }
    }
}
