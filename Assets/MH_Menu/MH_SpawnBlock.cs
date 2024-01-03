using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_SpawnBlock : MonoBehaviour
{
    public GameObject prefab;
    private int PutBlockDownX;
private int PutBlockDownY;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("h")){
        GameObject obj = (GameObject)Instantiate(prefab,new Vector3Int(PutBlockDownX,PutBlockDownY,0),transform.rotation);
        PutBlockDownX = Mathf.RoundToInt(GameObject.Find("charIdle1a").transform.position.x);
      PutBlockDownY = Mathf.RoundToInt(GameObject.Find("charIdle1a").transform.position.y + 2);
        }
   
    }
}
