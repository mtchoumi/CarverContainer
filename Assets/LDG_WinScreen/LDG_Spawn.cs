using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDG_Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 0;  
    float time = 0.0f;
    bool isPlaying = false;
    void Start()
    {
    
    }
    void Update()
    {   
         time += Time.deltaTime; 
         if (time >= interval)
        {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(Random.Range(-8f, -3f),10f),transform.rotation);
            GameObject obj2 = (GameObject)Instantiate(prefab, new Vector2(Random.Range(-2f, 3f),15f),transform.rotation);
            GameObject obj3 = (GameObject)Instantiate(prefab, new Vector2(Random.Range(4f, 8f),20f),transform.rotation);
            LDG_Display.score++; 
            time = 0f; 
        }
    }
}
