using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLM_Run_InstantiateTree : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float count = 0f;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
       x = Random.Range(-5f,5f);
       y = Random.Range(-5f,5f);
       

        if(count>1){
            if(x!=0&&y!=0){
          Instantiate(prefab,new Vector3(x+=transform.position.x,y+=transform.position.y,0),Quaternion.identity);
          count = 0;
            }
        }
    }
}
