using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMW_Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 1;
    float time = 0.0f; 

    void Update()
    {
        time += Time.deltaTime;
        if (time >= interval)
        {
            GameObject obj = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            time = 0f; 
        }
    }
}
