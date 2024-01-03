using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_SummonL : MonoBehaviour
{
    public GameObject prefab;
    private float interval3;
    private float time3; 
    private bool willSpawn;
    private float xPos;
    
    void Start()
    {
        interval3 = Random.Range(3, 5);
        xPos = Random.Range(-16, 16);
    }

    
    void Update()
    {
        GameObject w = GameObject.Find("xLimit Right");
        GGV_TimeDisplay t = w.GetComponent<GGV_TimeDisplay>();
        if(willSpawn == true)
        {
            interval3 = Random.Range(3, 4);
            xPos = Random.Range(-16, 16);
            willSpawn = false;
        }
        if(t.hasWon == false)
        {
        time3 += Time.deltaTime;
        }
        if(time3>= interval3)
        {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(xPos, 9.62f), Quaternion.Euler(0, 0, 0));
            willSpawn = true;
            time3 = 0;
        }

    }
}
