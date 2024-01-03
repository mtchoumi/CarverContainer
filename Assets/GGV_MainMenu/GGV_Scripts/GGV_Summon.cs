using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_Summon : MonoBehaviour
{
    public GameObject prefab;
    public bool WillSpawn = true;
    private float interval;
    private float time = 0.0f;
    public float Side = 1f; 
    private float yp;
    
    void Start()
    {
        Side = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject w = GameObject.Find("xLimit Right");
        GGV_TimeDisplay t = w.GetComponent<GGV_TimeDisplay>();
        if (WillSpawn == true)
        {
            interval = Random.Range(1, 2);

            yp = Random.Range(-5.5f, 6.5f);
            Side = Random.Range(-1, 1);

            WillSpawn = false;
        }
        if(t.hasWon == false)
        {
        time += Time.deltaTime;
        }
        if (time >= interval)
        {
            if (Side >= 0f)
            {
                GameObject obj = (GameObject)Instantiate(prefab, new Vector2(16f, yp), Quaternion.Euler(0, 0, 0));
                
            }else if (Side < 0f)
            {
                GameObject obj = (GameObject)Instantiate(prefab, new Vector2(-16f, yp), Quaternion.Euler(0, 0, 0));
            
            }
            time = 0.0f;
            WillSpawn = true;
        }
    }
}

