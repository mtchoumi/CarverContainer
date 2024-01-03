using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_Warning : MonoBehaviour
{
    private float interval2 = 3;
    private float time2 = 0.0f;
    private bool WillSpawn = true;
    public GameObject prefab;
    Transform tra;
    // Start is called before the first frame update
    void Start()
    {
        time2 = 0.0f;
        WillSpawn = true;
        tra = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject w = GameObject.Find("xLimit Right");
        GGV_TimeDisplay t = w.GetComponent<GGV_TimeDisplay>();
        time2 += Time.deltaTime;
        
        if(WillSpawn == true)
        {
            // if(time2 >= interval2){
                GameObject obj = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
                WillSpawn = false;
            // }
        }
        if (time2 >= interval2 + 0.3f)
       {
           Destroy(gameObject);
       }
       if(t.hasWon == true)
       {
           Destroy(gameObject);
       }

    }
    
}
