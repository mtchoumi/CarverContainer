using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TO_health_script1 : MonoBehaviour
{
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        print(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_Playermove.crash==true)
        {
//            health = health - 1;
            print(health);
        }
        if(health == 2)
        {
            Destroy(GameObject.Find("life_1"));
            print(health);
        }
    }
}
