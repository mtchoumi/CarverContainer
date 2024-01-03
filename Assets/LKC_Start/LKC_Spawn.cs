using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKC_Spawn : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
         //GameObject obj = Instantiate(prefab, new Vector3(Random.Range(-7.91f, 7.94f), 4.04f, 0f), Quaternion.identity);
        //time+= Time.deltaTime; 
        //if(time>=3)
        //{
            //GameObject obj = Instantiate(prefab, new Vector3(Random.Range(-7.91f, 7.94f), 4.04f, 0f), Quaternion.identity);
            //time = 0;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime; 
        if(time>=3)
        {
            GameObject obj = Instantiate(prefab, new Vector3(Random.Range(-7.91f, 7.94f), 4.04f, 0f), Quaternion.identity);
            time = 0;
        }

    }
     
}
